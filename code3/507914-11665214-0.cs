    public E FindByIdWithIncludes<E>(int id, string[] includes) 
        where E : class, IEntityWithId
    {          
        IQueryable<E> entityQuery = DataContext.Set<E>();
        foreach (var include in includes)
        {
                entityQuery = entityQuery.Include(include);
        }
        return entityQuery.SingleOrDefault(e => e.Id == id); 
    }
