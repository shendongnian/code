    public override int SaveChanges()
    {
        //you may need this line depending on your exact configuration
        //ChangeTracker.DetectChanges();
        foreach (DbEntityEntry o in GetChangedEntries())
        {
            IEntity entity = o.Entity as IEntity;
            entity.LastModified = DateTime.Now;
        }
        return base.SaveChanges();
    }
    private IEnumerable<DbEntityEntry> GetChangedEntries()
    {
        return new List<DbEntityEntry>(
            from e in ChangeTracker.Entries()
            where e.State != System.Data.EntityState.Unchanged
            select e);
    }
