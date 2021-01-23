    public static IQueryable<T> Including(
                              params Expression<Func<T, object>>[] includeProperties)
    {            
        IQueryable<T> query = DbContext.Set<T>();
    
        foreach (var includeProperty in includeProperties)    
            query = query.Include(includeProperty);    
    
        return query;
    }
