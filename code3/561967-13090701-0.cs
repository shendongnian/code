    static void Main(string[] args)
    {
    	IEnumerable<IEnumerable<string>> items = new string[][]
    	{
    		new [] { "Buildings" },
    		new [] { "Facilities" },
    		new [] { "Fields" },
    		new [] { "Files", "Groups", "Entity" },
    		new [] { "Controllers", "FX", "Steam" }
    	};
    
    	foreach (var c in Combinations(items))
    		Console.WriteLine(c);
    
    	Console.ReadLine();
    }
