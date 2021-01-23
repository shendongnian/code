    static readonly IDictionary<string, Func<object>> Types = new Dictionary<string, Func<object>>()
    {
    	{ "TypeA", () => new TypeA() },
    	{ "TypeB", () => new TypeB() },
    	{ "TypeC", () => new TypeC() },
    };
    
    // If you're okay with a bit of reflection behind-the-scenes, change "object"
    // here to "dynamic", and you won't have to cast down the road.
    object void GetInstance(string name)
    {
    	if (Types.ContainsKey(name))
    	{
    		return Types[name]();
    	}
    	else
    	{
    		return null;
    	}
    }
	
