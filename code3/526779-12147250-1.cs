    private static readonly Dictionary<Type, DynamicCreationDelegate> _cachedCreationDelegates = new Dictionary<Type, DynamicCreationDelegate>();
    
    private static DynamicCreationDelegate CreateOrGet(Type typeToCreate)
    {
    	DynamicCreationDelegate result = null;
    	
    	if (!_cachedCreationDelegates.TryGetValue(typeToCreate, out result))
    	{
    		result = FastActivator.GenerateDelegate(typeToCreate, 
    		/* List of types that make up the constructor signature of the type being constructed */
    		typeof(SPListItem), typeof(List<Vote>));
    		_cachedCreationDelegates.Add(result);
    	}
    	
    	return result;
    }
    
    // Usage 
    for (int i = 0; i < items.Count; i++) 
    { 
    	var creationDelegate = CreateOrGet(typeof(genericType));
    	returnlist.Add((T)creationDelegate(new object[] { items[i], votes })); 
    }
