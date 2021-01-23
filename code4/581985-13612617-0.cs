    protected override int SaveChanges()
    {
         foreach (var entry in ChangeTracker.Entries<Clients())
         {
            var entity = entry.Entity;
            if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
            {
                entry.Entity.SerializeExtended();
            }
         }
         base.SaveChanges();
    }
