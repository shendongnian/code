    // In our SaveChanges wrapper:
            var entries = context.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified | EntityState.Deleted);
    
            private static void PopulateDate(IEnumerable<ObjectStateEntry> entries)
                    {
                        foreach (var entry in entries)
                        {
                            if (entry.State != EntityState.Deleted)
                            {
                                if ((entry.Entity != null) && (entry.Entity.GetType().GetProperty("LastUpdatedDateTime") != null))
                                {
                                    ((dynamic)entry.Entity).LastUpdatedDateTime = DateTime.UtcNow;
                                }
                            }
                        }
                    }
