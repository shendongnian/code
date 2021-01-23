    public List<PropertyInfo> GetAllProperties(Type type)
    {
    	var result = new List<PropertyInfo>();
    	var queue = new Queue<Type>();
    	var processedTypes = new HashSet<Type>();
    
    	queue.Enqueue(type);
    	while (queue.Count > 0)
    	{
    		var currentType = queue.Dequeue();
    		processedTypes.Add(currentType);
    
    		var properties = currentType.GetProperties();
    		result.AddRange(properties);
    
    		var typesToProcess = properties
    			.Select(p => p.PropertyType)
    			.Distinct()
    			.Where(pt => !pt.IsPrimitive)
    			.Where(pt => !processedTypes.Contains(pt));
    
    		foreach(var t in typesToProcess)
    		{
    			queue.Enqueue(t);
    		}
    	}
    
    	return result;
    }
