    public override int SaveChanges()
    {
        foreach( var entity in ChangeTracker.Entries()
                                            .Where(e => e.State == EntityState.Added)
                                            .Select (e => e.Entity)
                                            .OfType<BaseEntity>())
        {
            entity.SetAuditValues(DateTimeOffset.Now, this.CreatedBy);
        }
        return base.SaveChanges();
    }
