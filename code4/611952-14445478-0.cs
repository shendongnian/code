    public virtual int Update<T>(T TObject) where T : class, ILastModified
    {
        TObject.LastModified = DateTime.Now
        var entry = dbContext.Entry(TObject);
        dbContext.Set<T>().Attach(TObject);
        entry.State = EntityState.Modified;
        return dbContext.SaveChanges();
    }
