    static readonly IDictionary<string, Type> Instances = new Dictionary<string, type>()
    {
    	{ "TypeA", new TypeA() },
    	{ "TypeB", new TypeB() },
    	{ "TypeC", new TypeC() },
    };
    
    object void GetInstance(string name)
    {
    	if (!Types.ContainsKey(name))
    	{
    		return null;
    	}
    	
    	return Instances[name];
    }
