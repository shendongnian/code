    public void Update(TEntity entityToUpdate)
    {
        if (context.Entry(entityToUpdate).State == EntityState.Detached)
        {
            context.Set<TEntity>().Attach(entityToUpdate);
        }
        context.Entry(entityToUpdate).State = EntityState.Modified;
    }
