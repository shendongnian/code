	void Main()
	{
		var f = new FooClass();
		f.Foo();
	}
	
	class BarClass
	{
		public static void Bar()
		{
			var st = new StackTrace();
			var frame = st.GetFrame(1);
			var m = frame.GetMethod();
			Console.WriteLine(String.Format("'{0}' called me from '{1}'", m.DeclaringType.Name, m));
		}
	}
	
	class FooClass
	{
		public void Foo()
		{
			BarClass.Bar();
		}
	}
