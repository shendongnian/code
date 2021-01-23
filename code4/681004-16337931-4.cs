    public static dynamic CreateRepository(object entiry, Type targetType)
    {
    	Type BaseType = typeof(Repository<>);	
    	Type ConcreteType = BaseType.MakeGenericType(targetType);
    	var Instance = Activator.CreateInstance(ConcreteType, entiry);
    		
    	return DynamicCast(Instance, ConcreteType);
    }
