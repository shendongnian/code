    private ConcurrentDictionary<Type, ISomeObject> someObjectCache = 
        new ConcurrentDictionary<Type, ISomeObject>();
    public ISomeObject CreateSomeObject(Type someType)
    {
        ISomeObject someObject; 
        if (someObjectCache.TryGet(someType, out someObject))
        {
           return someObject;
        }
        if (Attribute.IsDefined(someType, typeof(SomeAttribute)) 
        { 
            // init someObject here
			someObject = new SomeObject(); 
			
			return someObjectCache.GetOrAdd(someType, someObject); // If another thread got through here first, we'll return their object here. 
        }
		
		// fallback functionality goes here if it doesn't have your attribute. 
    }
