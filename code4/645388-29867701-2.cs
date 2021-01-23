    public void Update(T obj, params Expression<Func<T, object>>[] propertiesToUpdate)
    {
        Context.Set<T>().Attach(obj);
        foreach (var p in propertiesToUpdate)
        {
            Context.Entry(obj).Property(p).IsModified = true;
        }
    }
