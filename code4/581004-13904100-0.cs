            using (var transaction = Connection.BeginTransaction())
            {
   		    try
                    {
                        SaveChanges();
                        transaction.Commit();
                    }
                    catch (OptimisticConcurrencyException)
                    {
                        if (ObjectStateManager.GetObjectStateEntry(entity).State == EntityState.Deleted || ObjectStateManager.GetObjectStateEntry(entity).State == EntityState.Modified)
                            this.Refresh(RefreshMode.StoreWins, entity);
                        else if (ObjectStateManager.GetObjectStateEntry(entity).State == EntityState.Added)
                            Detach(entity);
                        AcceptAllChanges(); 
                        transaction.Commit();
                    }
            }
        }
