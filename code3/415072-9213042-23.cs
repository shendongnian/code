    static readonly IDictionary<string, object> Instances = new Dictionary<string, object>()
    {
    	{ "TypeA", new TypeA() },
    	{ "TypeB", new TypeB() },
    	{ "TypeC", new TypeC() },
    };
    
    object void GetInstance(string name)
    {
    	if (!Instances.ContainsKey(name))
    	{
    		return null;
    	}
    	
    	return Instances[name];
    }
