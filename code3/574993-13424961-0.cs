    public virtual IQueryable<T> GetIncluding(Expression<Func<T,bool>> predicate, 
                              params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = DbContext.Set<T>().Where(predicate);
    
        foreach (var includeProperty in includeProperties)    
            query = query.Include(includeProperty);    
    
        return query;
    }
