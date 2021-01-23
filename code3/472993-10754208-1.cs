    public static object CreateGeneric(Type generic, Type innerType, params object[] args)
    {
    	System.Type specificType = generic.MakeGenericType(new System.Type[] { innerType });
    	return Activator.CreateInstance(specificType, args);
    }
