    public object CreateList(Type elementType, object initialValue)
    {
    	if (!elementType.IsAssignableFrom(initialValue.GetType()))
    		throw new ArgumentException("Incompatible types!");
    
    	Type unboundType = typeof(List<>);
    	Type listType = unboundType.MakeGenericType(elementType);
    	object list = Activator.CreateInstance(listType);
    	var addMethod = listType.GetMethod("Add");
    	addMethod.Invoke(list, new []{initialValue});
    	return list;
    }
