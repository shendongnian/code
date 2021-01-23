    public virtual void Save(TModel t)
    {
            TModel unboxed = (TModel)t;
            db.AttachTo(entitySetName, unboxed);
            db.ObjectStateManager.ChangeObjectState(unboxed, EntityState.Modified);
            db.SaveChanges();
    }
