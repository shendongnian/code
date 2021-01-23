    public override int SaveChanges()
    {
          var entires = ChangeTracker.Entries()
                                     .Where(e => e.State == EntityState.Modified)
          foreach (var entry in entires)
          {
                var auditableEntity = entry.Entity as IAuditable;
                if (entry.Entity != null)
                    auditableEntity.LastUpdateDate = DateTime.UtcNow;
          }
          
          base.SaveChanges();
    }
