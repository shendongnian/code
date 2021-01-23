    public override int SaveChanges()
    {
        foreach(IAuditData item in GetChangedAuditDataEntities())
        {
            //...... update the entity
        }
        return base.SaveChanges();
    }
    private IEnumerable<IAuditData> GetChangedAuditDataEntities()
    {
        return (
            from entry in ChangeTracker.Entries()
            where entry.State != EntityState.Unchanged
            select entry)
            .OfType<IAuditData>();
    }
