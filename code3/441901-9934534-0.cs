    public void Insert(TClass entity)
    {
        if (Context.Entry(entity).State == EntityState.Detached)
            Context.Set<TClass>().Attach(entity);
        Context.Set<TClass>().Add(entity);
        Context.SaveChanges();
    }
