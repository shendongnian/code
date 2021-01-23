    public IList CreateList(Type elementType, object initialValue)
    {
    	if (!elementType.IsAssignableFrom(initialValue.GetType()))
    		throw new ArgumentException("Incompatible types!");
    
    	Type unboundType = typeof(List<>);
    	Type listType = unboundType.MakeGenericType(elementType);
    	IList list = (IList)Activator.CreateInstance(listType);
    	list.Add(initialValue);
    	return list;
    }
