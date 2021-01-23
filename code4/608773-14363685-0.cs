    public TEntity DeleteOne(TEntity entity)
    {
        DbContext.Attach(entity);
        DbContext.Remove(entity);
        Entities.Remove(entity);
        DbContext.SaveChanges();
        return entity;
    }
