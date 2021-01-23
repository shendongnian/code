    public T Create(long id) {
        T entity = _dbContext.Set<T>().Create();
        entity.Id = id;
        _dbContext.Set<T>().Attach(entity);
        return entity;
    }
