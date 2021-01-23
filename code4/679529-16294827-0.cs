    if (typeof(ICloseable).IsAssignableFrom(typeof(T)))
    {
        IQueryable<ICloseable> closeables = (IQueryable<ICloseable>) base.Set<T>();
        return closeables.Where(n => !n.Closed).Cast<T>();
    }
