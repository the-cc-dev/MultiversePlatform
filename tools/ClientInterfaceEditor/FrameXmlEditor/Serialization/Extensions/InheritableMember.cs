/********************************************************************

The Multiverse Platform is made available under the MIT License.

Copyright (c) 2012 The Multiverse Foundation

Permission is hereby granted, free of charge, to any person 
obtaining a copy of this software and associated documentation 
files (the "Software"), to deal in the Software without restriction, 
including without limitation the rights to use, copy, modify, 
merge, publish, distribute, sublicense, and/or sell copies 
of the Software, and to permit persons to whom the Software 
is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be 
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES 
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING 
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE 
OR OTHER DEALINGS IN THE SOFTWARE.

*********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Microsoft.MultiverseInterfaceStudio.FrameXml.Serialization
{
	public class InheritableMember<T>
	{
		public InheritableMember() 
		{
		}
		
		public InheritableMember(T value)
		{
			this.Value = value;
		}

		private T value;
		public T Value
		{
			get
			{
				return value != null ?
					value :
					InheritsFrom != null ?
						InheritsFrom.Value :
						default(T);
			}
			set 
			{ 
				this.value = value; 
			}
		}

		public InheritableMember<T> InheritsFrom { get; set; }

		//public static explicit operator T(InheritableMember<T> value)
		//{
		//    return value.Value;
		//}

		public static implicit operator InheritableMember<T>(T value)
		{
			return new InheritableMember<T>(value);
		}

		public static implicit operator T(InheritableMember<T> value)
		{
			return value.Value;
		}
	}
}
