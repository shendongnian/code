    public IEnumerable<T> GetRecords()
    {
        IQueryable<T> entities = new List<T>().AsQueryable();
        if (typeof(IFilterable).IsAssignableFrom(typeof(T)))
        {
            entities = FilterMe<IFilterable, T>(entities.OfType<IFilterable>()).AsQueryable();
        }
        return entities;
    }
    public IEnumerable<TResult> FilterMe<TSource, TResult>(IEnumerable<TSource> linked) where TSource : IFilterable
    {
        return linked.Where(r => true).OfType<TResult>();
    }
