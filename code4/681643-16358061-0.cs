    public virtual void Update(T entity)
    {
        DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
        var attachedEntity = DbSet.Find(entity.Id);
        if (attachedEntity != null)
        {
            var attachedEntry = DbContext.Entry(attachedEntity);
            entity.Created = attachedEntity.Created;
            entity.LastModified = DateTime.Now;
            attachedEntry.CurrentValues.SetValues(entity);
        }
        else
        {
            dbEntityEntry.State = EntityState.Modified;
            entity.LastModified = DateTime.Now;
        }
    }
