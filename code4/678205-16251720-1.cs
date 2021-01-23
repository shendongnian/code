    void Main()
    {
    	var dogs = new List<Dog>();
    	dogs.Add(new Dog { Name = "Max", Breed = "Mutt", Legs = 4 });
    	foreach (var dog in dogs)
    	{
    		// do something
    	}
    }
    
    class Dog
    {
        public int Legs { get; set; }
    	public string Breed { get; set; }
    	public string Name { get; set; }
    }
