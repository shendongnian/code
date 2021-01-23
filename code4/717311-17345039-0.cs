        internal static void UndoContextChange(DB_Context db)
        {
            foreach (var item in db.ChangeTracker.Entries())
            {
                if (item.State == System.Data.EntityState.Modified)
                {
                    item.State = System.Data.EntityState.Unchanged;
                }
                else if (item.State == System.Data.EntityState.Deleted)
                {
                    item.State = System.Data.EntityState.Unchanged;
                    item.CurrentValues.SetValues(item.OriginalValues); //just in case
                }
                else if (item.State == System.Data.EntityState.Added)
                {
                    item.State = System.Data.EntityState.Detached;
                }
            }        
        }
