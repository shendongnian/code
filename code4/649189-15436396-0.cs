   	static void Main(string[] args)
	{
		var dict = new Dictionary<string, Foo>();
		var number = 10000000;
		for (int i = 0; i < number; i++)
		{
			dict[i.ToString()] = new Foo();
		}
		var watch = new Stopwatch();
		
		watch.Start();
		for (int i = 0; i < number; i++)
		{
			var key = i.ToString();
			dict[key].A = "a";
			dict[key].B = "b";
			dict[key].C = "c";
			dict[key].D = "d";
		}
		watch.Stop();
		Console.Out.WriteLine(watch.ElapsedMilliseconds);
		
		watch.Reset();
		watch.Start();
		for (int i = 0; i < number; i++)
		{
			var key = i.ToString();
			var foo = dict[key];
			foo.A = "a";
			foo.B = "b";
			foo.C = "c";
			foo.D = "d";
		}
		watch.Stop();
		Console.Out.WriteLine(watch.ElapsedMilliseconds);
	}	
	class Foo
	{
		public string A { get; set; }
		public string B { get; set; }
		public string C { get; set; }
		public string D { get; set; }
	}
