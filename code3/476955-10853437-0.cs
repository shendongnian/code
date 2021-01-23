    public IQueryable<T> AllIncluding(
        params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = All as DbQuery<T>;
        if (query == null)
        {
           return All;
        }
        
        foreach (var includeProperty in includeProperties)
        {
            // query = query.Include(includeProperty);
        }
        return query;
    }
