    DbContext context = // ...
    foreach (var entityEntry in context.ChangeTracker.Entries())
    {
        if (entityEntry.State == EntityState.Modified)
             entityEntry.State = EntityState.Added;
    }
    ct.SaveChanges();
