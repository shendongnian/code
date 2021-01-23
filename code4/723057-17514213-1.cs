	void Main()
	{
		var reader = CreateReader(typeof(Foo));
		reader(new Foo { Bar = "BARRRRR", Baz = 123 }).Dump();
	}
	
	public class Foo
	{
		public string Bar {get; set;}
		public int Baz {get; set;}
	}
	
	
	static ConstructorInfo Ctor = typeof(KeyValuePair<string, object>).GetConstructor(new Type[] { typeof(String), typeof(Object) });
	
	static Func<object, IEnumerable<KeyValuePair<string, object>>> CreateReader(Type t)
	{
		var prm = Expression.Parameter(typeof(Object), "prm");
		var obj = Expression.Variable(t, "obj");
		var arr = new List<Expression>();
	
		foreach (var p in t.GetProperties(BindingFlags.Public | BindingFlags.Instance))
		{
			arr.Add(Expression.New(Ctor, Expression.Constant(p.Name), Expression.Convert(Expression.Property(obj, p), typeof(Object))));
		}
		
		var body = Expression.Block(
			typeof(IEnumerable<KeyValuePair<string, object>>),
			new ParameterExpression[] { obj },
			Expression.Assign(obj, Expression.Convert(prm, t)),
			Expression.NewArrayInit(typeof(KeyValuePair<string, object>), arr)
		);
		
		return Expression.Lambda<Func<object, IEnumerable<KeyValuePair<string, object>>>>(body, prm).Compile();
	}
