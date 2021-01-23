    void Main()
    {
    	var feeder = new Subject<char>();	
    	var query = feeder.Split(' ');
    		
    	using(query.Subscribe(Console.WriteLine))
    	{
    		foreach(var c in "this should split words on spaces ".ToCharArray())
    		{
    			feeder.OnNext(c);
    		}
    		Console.ReadLine();
    	}		
    }
