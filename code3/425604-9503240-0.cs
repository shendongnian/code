    void Main()
    {
    	List<IFoo> foos = new List<IFoo>
    	{
    		new Bar2{ Name = "Pqr", Price = 789.15m, SomeNumber = 3 },
    		new Bar2{ Name = "Jkl", Price = 444.25m, SomeNumber = 1 },
    		new Bar1{ Name = "Def", Price = 222.5m, SomeDate = DateTime.Now },
    		new Bar1{ Name = "Ghi", Price = 111.1m, SomeDate = DateTime.Now },
    		new Bar1{ Name = "Abc", Price = 123.45m, SomeDate = DateTime.Now },
    		new Bar2{ Name = "Mno", Price = 564.33m, SomeNumber = 2 }
    		
    	};
    	
    	foos.Sort((x,y) => x.Name.CompareTo(y.Name));
    	foreach(IFoo foo in foos)
    	{
    		Console.WriteLine(foo.Name);
    	}
    	
    	foos.Sort((x,y) => x.Price.CompareTo(y.Price));
    	foreach(IFoo foo in foos)
    	{
    		Console.WriteLine(foo.Price);
    	}
    }
    
    interface IFoo
    {
    	string Name { get; set; }
    	decimal Price { get; set; }
    }
    
    class Bar1 : IFoo
    {
    	public string Name { get; set; }
    	public decimal Price { get; set; }
    	public DateTime SomeDate { get; set; }
    }
    
    class Bar2 : IFoo
    {
    	public string Name { get; set; }
    	public decimal Price { get; set; }
    	public int SomeNumber { get; set; }
    }
