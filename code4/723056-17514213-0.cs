	void Main()
	{
		var reader = CreateReader<Foo>();
		reader(new Foo { Bar = "BARRRRR", Baz = 123 }).Dump();
	}
	
	public class Foo
	{
		public string Bar {get; set;}
		public int Baz {get; set;}
	}
	
	
	static ConstructorInfo Ctor = typeof(KeyValuePair<string, object>).GetConstructor(new Type[] { typeof(String), typeof(Object) });
	
	static Func<T, IEnumerable<KeyValuePair<string, object>>> CreateReader<T>()
	{
		var obj = Expression.Parameter(typeof(T), "obj");
		var arr = new List<Expression>();
	
		foreach (var p in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
		{
			arr.Add(Expression.New(Ctor, Expression.Constant(p.Name), Expression.Convert(Expression.Property(obj, p), typeof(Object))));
		}
		
		return Expression.Lambda<Func<T, IEnumerable<KeyValuePair<string, object>>>>(Expression.NewArrayInit(typeof(KeyValuePair<string, object>), arr), obj).Compile();
	}
