    ConcurrentDictionary<Type, object> _repositories = ...;
    public GenericRepository<IRepository<TEntity>> Repository<TEntity>(IRepositoryEntity entity) where TEntity: IRepositoryEntity
    {
        return (GenericRepository<IRepository<TEntity>>)_repositories.GetOrAdd(
            typeof(TEntity), 
            t => new GenericRepository<IRepository<TEntity>>(this.Context)
        );
    }
