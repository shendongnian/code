    public override int SaveChanges()
    {
          var entries = ChangeTracker.Entries()
                                     .Where(e => e.State == EntityState.Modified)
          foreach (var entry in entries)
          {
                var auditableEntity = entry.Entity as IAuditable;
                if (auditableEntity  != null)
                    auditableEntity.LastUpdateDate = DateTime.UtcNow;
          }
          
          base.SaveChanges();
    }
