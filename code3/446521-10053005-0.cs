		public class MyClass
		{
			public String[] keys { get; private set; }
			public MyClass(String[] keys) { this.keys = keys; }
		}
		public List<MyClass> GetMyClassList()
		{
			return new List<MyClass>
			       {
			       	new MyClass(new[] {"one", "two", "three"}),
			       	new MyClass(new[] {"four", "five", "six"})
			       };
		}
		public Dictionary<string, MyClass> Test()
		{
			return GetMyClassList()
				.SelectMany(mc => mc.keys.Select(s => new KeyValuePair<String, MyClass>(s, mc)))
				.ToDictionary(p => p.Key, p => p.Value);
		}
