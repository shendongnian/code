        public async Task RollbackChanges()
        {
            var oldBehavoir = ChangeTracker.QueryTrackingBehavior;
            var oldAutoDetect = ChangeTracker.AutoDetectChangesEnabled;
            // this is the key - disable change tracking logic so EF does not check that there were exception in on of tracked entities
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
            var entries = ChangeTracker.Entries().ToList();
            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        await entry.ReloadAsync();
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified; //Revert changes made to deleted entity.
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
            ChangeTracker.QueryTrackingBehavior = oldBehavoir;
            ChangeTracker.AutoDetectChangesEnabled = oldAutoDetect;
        }
