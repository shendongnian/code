    void Main()
    {
        var MyDictionary = new Dictionary<int, Regex>() 
       	{
       		{1, new Regex("Bar")},
       		{2, new Regex("nothing")},
       		{3, new Regex("r")}
       	};
        var text = "FooBar";
       
    	var results = from kvp in MyDictionary
    				  let match = kvp.Value.Match(text)
    				  where match.Success
    				  select new 
    				  {
    						ID = kvp.Key,
    						Index = match.Index
    				  };
    		
    	results.Dump();	
    }
