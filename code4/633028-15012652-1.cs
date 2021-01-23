    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries<Foo>())
        {
            if (entry.State == System.Data.EntityState.Modified)
            {
                // use entry.OriginalValues
                Foo originalFoo = CreateWithValues<Foo>(entry.OriginalValues);
            }
        }
        return base.SaveChanges();
    }
