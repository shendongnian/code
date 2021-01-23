    public void Delete<TEntity>(TEntity entity) where TEntity : class, IEntity
    {
        this.Configuration.ValidateOnSaveEnabled = false;
        TEntity alreadyAttached = this.Set<TEntity>().Local
                                      .FirstOrDefault(d=>d.Id == entity.Id);
        if(alreadyAttached != null) entity = alreadyAttached;
        this.Entry<TEntity>(entity).State = EntityState.Deleted;
        SaveChanges();
        this.Configuration.ValidateOnSaveEnabled = true;
     }
