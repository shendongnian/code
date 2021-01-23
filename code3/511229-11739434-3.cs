    public object MakeRepository(string entityTypeName)
    {
    	Assembly common = Assembly.LoadFrom(@"CommonLibrary.dll");
    	Type entityType = common.GetType(entityTypeName);
    	Type repoType = typeof(TradeSiftRepository<>).MakeGenericType(entityType);
    
    	var repo = Activator.CreateInstance(repoType, new UnitOfWork());
        return repo;
    }
    
    IRepository<User> userRepository = (IRepository<User>)MakeRepository("User");
