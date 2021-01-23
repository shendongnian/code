    void InsertEntity<TEntity>(TEntity newEntity, Func<myEntity, TEntity> insertCallback) where TEntity : EntityObject
    {
        using(var dbContext = new myEntity())
        {
            insertCallback(dbContext, newEntity);
            dbContext.SaveChanges();
        }
    }
