	var fetch = new Dictionary<string, Func<Context, IQueryable<MyClass>>>()
	{
		{ "94", db => db.Table94.Select(i => new MyClass(i.A, i.B, i.C)) },
		{ "95", db => db.Table95.Select(i => new MyClass(i.A, i.B, i.C)) },
	};
