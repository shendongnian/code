    public virtual T GetByIdIncluding(long id, params Expression<Func<T, object>>[] includeProperties)
    {
        var query = DbContext.Set<T>();
         foreach (var includeProperty in includeProperties)
         {
             query = query.Include(includeProperty);
         }
        return query.Find(id);
    }
