	using System;
	
	class A<T>
	{
		static A() { }
		public A(out string s) {
			s = String.Empty;
		}
	}
	class B
	{
		static void Main() { 
			string s;
			new A<Object>(out s);
			//new A<Int32>(out s);
			Console.WriteLine(s.Length);
		}
	}
