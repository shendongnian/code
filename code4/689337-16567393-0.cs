    public override int SaveChanges()
    {
        if (changeSet != null)
            foreach (var dbEntityEntry in ChangeTracker.Entries())
            {
                switch (dbEntityEntry.State)
                {
                    case EntityState.Added:
                        // log your data
                        break;
                    case EntityState.Modified:
                        // log your data
                        break;
                }
            }
        return base.SaveChanges();
    }
