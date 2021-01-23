	class Foo
	{
		public void Test()
		{
			var instance = Expression.Constant(this);
			var body = Expression.Call(instance, GetType().GetMethod("ToString"));
			var exp = Expression.Lambda<Func<string>>(body);
			Console.WriteLine(exp.Compile()());
		}
	}
