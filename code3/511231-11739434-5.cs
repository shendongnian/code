    public IRepository<TEntity> MakeRepository<TEntity>() where TEntity : class
    {
    	var repo = new TradeSiftRepository<TEntity>(new UnitOfWork());
    	return repo;
    }
    
    IRepository<User> userRepository = MakeRepository<User>();
