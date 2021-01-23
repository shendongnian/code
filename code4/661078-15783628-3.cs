    {
	private static Foo(object value)
	{
		object bar = value;
		//...
	}
	private static void Main()
	{
		object obj = new object();
		Foo(obj);
		Foo(obj);
		//...
	}
