    if (typeof(IDictionary).IsAssignableFrom(propertyType))
    {
    	Type keyType = propertyType.GetGenericArguments()[0],
    		 valueType = propertyType.GetGenericArguments()[1];
    	Type hashsetType = typeof(HashSet<>).MakeGenericType(keyType);
    	var hashsetCtor = hashsetType.GetConstructor(new[] { typeof(IEnumerable<>).MakeGenericType(keyType) });
    
    	dynamic aDict = a;
    	dynamic bDict = b;
    	dynamic aKeys = hashsetCtor.Invoke(new object[] { aDict.Keys });
    	dynamic bKeys = hashsetCtor.Invoke(new object[] { bDict.Keys });
    
    	List<ChangedProperty> changes = new List<ChangedProperty>();
    	foreach (var key in Enumerable.Intersect(aKeys, bKeys))
    	{
          	    // Present in both dictionaries. Recurse further
    	}
    	foreach (var key in Enumerable.Except(aKeys, bKeys))
    	{
              // Key was removed
    	}
    	foreach (var key in Enumerable.Except(bKeys, aKeys))
    	{
              // Key was added
    	}
    
    	return changes;
    }
