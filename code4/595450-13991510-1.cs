    public static IEnumerable<Type> GetAvailableRepositoryClasses()
    {
    	return Assembly.GetExecutingAssembly().GetTypes()
    		.Where(t => t.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof (IRepository<>)));
    }
