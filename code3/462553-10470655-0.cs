    void Main()
    {
    	Process(GetInts());
    	Process(GetBools());
    }
    
    IEnumerable<int> GetInts()
    {
        return new List<int>{1,2,3};
    }
    
    IEnumerable<bool> GetBools()
    {
    	return new List<bool>{true, false, true};
    }
    
    void Process<T>(IEnumerable<T> items)
    {
    	foreach (var item in items)
    	{
    		if(item is int)
    		{
    		   Debug.WriteLine("int: " + item.ToString());
    		}
    		if(item is bool)
    		{
    		   Debug.WriteLine("bool: " + item.ToString());
    		}
    	}
    }
