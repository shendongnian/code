	void Main()
	{
                //Me being lazy in init
		var foos = new []
		{
			new Foo { Id = 1, Value = 5},
			new Foo { Id = 1, Value = 7},
			new Foo { Id = 2, Value = 1},
			new Foo { Id = 3, Value = 6},
			new Foo { Id = 3, Value = 2},
		};
		foreach(var x in foos)
		{
			x.Name = "Name" + x.Id;
			x.Category = "Category" + x.Id;
		}
                //end init.
		
		var result = from x in foos
					group x.Value by new { x.Id, x.Name, x.Category}
					into g
					select new { g.Key.Id, g.Key.Name, g.Key.Category, Value = g.Sum()};
		Console.WriteLine(result);
	}
	
	// Define other methods and classes here
	public class Foo
	{
		public int Id {get;set;}
		public int Value {get;set;}
		
		public string Name {get;set;}
		public string Category {get;set;}	
	}
