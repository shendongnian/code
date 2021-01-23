    foreach (var entry in context.ChangeTracker.Entries<Foo>())
    {
        if (entry.State == System.Data.EntityState.Modified)
        {
            // use entry.OriginalValues
            Foo originalFoo = CreateWithValues<Foo>(entry.OriginalValues);
        }
    }
