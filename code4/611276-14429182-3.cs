    public void Save(T entity, params Expression<Func<T, TProperty>>[] properties) {
        ...
        _dbContext.Set<T>().Attach(entity);
        if (properties.Length > 0) {
            foreach (var propertyAccessor in properties) {
                _dbContext.Entry(entity).Property(propertyAccessor).IsModified = true;
            }
        } else {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
