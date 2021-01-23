	class A<T>
	{
		static A() { }
		public A(out string s) {
			s = string.Empty;
		}
	}
	class B
	{
		static void Main() { 
			string s;
			new A<object>(out s);
			//new A<int>(out s);
			System.Console.WriteLine(s.Length);
		}
	}
