    private static Boolean MatchingBaseType(IEnumerable a, IEnumerable b)
    {
    	return GetIListBaseType(a) == GetIListBaseType(b);
    }
    
    private static Type GetIListBaseType(IEnumerable a)
    {
    	foreach (Type interfaceType in a.GetType().GetInterfaces())
    	{
    		if (interfaceType.IsGenericType &&
    			(interfaceType.GetGenericTypeDefinition() == typeof(IList<>) ||
    			 interfaceType.GetGenericTypeDefinition() == typeof(IEnumerable<>) ||
    			 interfaceType.GetGenericTypeDefinition() == typeof(ICollection<>))
    		)
    		{
    			return interfaceType.GetGenericArguments()[0];
    		}
    	}
    	return default(Type);
    }
