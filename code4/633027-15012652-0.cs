    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries<Foo>())
        {
            if (entry.State == System.Data.EntityState.Modified)
            {
                // use entry.OriginalValues
            }
        }
        return base.SaveChanges();
    }
