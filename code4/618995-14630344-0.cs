    static TInterface GetImplementation<TInterface>( Assembly assembly)
    {
    	var types = assembly.GetTypes();
    	Type implementationType = types.SingleOrDefault(t => typeof (TInterface).IsAssignableFrom(t) && t.IsClass);
    
    
    	if (implementationType != null)
    	{
    		TInterface implementation = (TInterface)Activator.CreateInstance(implementationType);
    		return implementation;
    	}
    	
    	throw new Exception("No Type implements interface.");    	
    }
