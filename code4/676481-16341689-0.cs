    public IQueryable<T> GetRecords()
    {
        var entities = Repository.Query<T>();
        if (typeof(IFilterable).IsAssignableFrom(typeof(T)))
        {
            entities = FilterMe(entities.OfType<IFilterable>()));
        }
        return entities;
    }
