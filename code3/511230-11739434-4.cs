    public dynamic MakeRepository(string entityTypeName)
    {
    	Assembly common = Assembly.LoadFrom(@"CommonLibrary.dll");
    	Type entityType = common.GetType(entityTypeName);
    	Type repoType = typeof(TradeSiftRepository<>).MakeGenericType(entityType);
    
    	var repo = Activator.CreateInstance(repoType, new UnitOfWork());
    	return repo;
    }
    
    dynamic userRepository = MakeRepository("ConsoleApplication1.User");
    User user = userRepository.FindById(1);
