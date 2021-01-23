	class Foo
	{
		public string TestProperty
		{
			get { return "It works."; }
		}
		public void Test()
		{
			var instance = Expression.Constant(this);
			var body = Expression.Property(instance, "TestProperty");
			var exp = Expression.Lambda<Func<string>>(body);
			Console.WriteLine(exp.Compile()());
		}
	}
