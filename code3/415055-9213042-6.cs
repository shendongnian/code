    static readonly IDictionary<string, Type> Types = new Dictionary<string, type>()
    {
    	{ "TypeA", typeof(TypeA) },
    	{ "TypeB", typeof(TypeB) },
    	{ "TypeC", typeof(TypeC) },
    };
    
    dynamic void GetInstance(string name)
    {
    	if (!Types.ContainsKey(name))
    	{
    		return null;
    	}
    	
    	ConstructorInfo ctor = Types[name].GetCosntructor(Type.EmptyTypes);
    	if (ctor == null)
    	{
    		return null;
    	}
    	
    	return (dynamic)ctor.Invoke(new object[0]);
    }
	
