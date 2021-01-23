    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.State == System.Data.EntityState.Added)
            {
                if (entry.Entity is IValidatableEntity)
                {
                    try
                    {
                        (entry.Entity as IValidatableEntity).Validate();
                    }
                    catch
                    {
                        entry.State = System.Data.EntityState.Detached;
                            
                        throw; // preserve the stack trace
                    }
                }
            }
        }
        return base.SaveChanges();
    }
