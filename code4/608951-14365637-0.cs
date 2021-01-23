        public override int SaveChanges()
        {
            DateTime now = DateTime.UtcNow;
            foreach (ObjectStateEntry entry in (this as IObjectContextAdapter).ObjectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified))
            {
                if (!entry.IsRelationship)
                {
                    IHasLastModified lastModified = entry.Entity as IHasLastModified;
                    if (lastModified != null)
                        lastModified.LastModified = now;
                }
            }
            int changes = base.SaveChanges();
            return changes;
        }
