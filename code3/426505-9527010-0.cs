	void Main()
	{
		var foo = new Foo();
		foo.Set("bar","test");
		Console.WriteLine(foo.Get("bar"));
	}
	class Foo
	{
		string bar;
		string bop;
		
		public void Set(string name, string value)
		{
			GetType().GetField(name, BindingFlags.NonPublic|BindingFlags.Instance)
                     .SetValue(this, value);
		}
		
		public string Get(string name)
		{
			return (string)GetType().GetField(name, BindingFlags.NonPublic|BindingFlags.Instance)
                                    .GetValue(this);
		}
	}
