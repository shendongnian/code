    IDictionary<string, object> Pool = new Dictionary<string, object>();
    
    object RetrieveFromPool(string typeName)
    {
    	if (Pool.ContainsKey(typeName))
    	{
    		return Pool[typeName];
    	}
    	
    	Type type = Type.GetType(typeName);
    	if (type == null)
    	{
    		return null;
    	}
    	
    	ConstructorInfo ctor = type.GetConstructor(Type.EmptyTypes);
    	if (ctor == null)
    	{
    		return null;
    	}
    	
    	object obj = ctor.Invoke(new object[0]);
    	Pool[typeName] = obj;
    	return obj;
    }
