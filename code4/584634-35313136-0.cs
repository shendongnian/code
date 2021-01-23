    var objContext = ((IObjectContextAdapter)ctx).ObjectContext;
         var entry = dbUpdateConcurrencyException.Entries.Single();
         if (entry.State == EntityState.Deleted)
         {
               entry.State = EntityState.Detached;
          }
          else
          {
               entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                objContext.Refresh(RefreshMode.ClientWins,dbUpdateConcurrencyException.Entries.Select(e => e.Entity));
           }
