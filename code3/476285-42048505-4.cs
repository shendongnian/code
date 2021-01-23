    public class MyContext : DbContext
    {
        //...
        public override int SaveChanges()
        {
            HandleOrphans();
            return base.SaveChanges();
        }
        private void HandleOrphans()
        {
            var orphanedEntities =
                ChangeTracker.Entries()
                .Where(x => x.Entity.GetType().BaseType == typeof(ChildObject))
                .Select(x => ((ChildObject)x.Entity))
                .Where(x => x.ParentObject == null)
                .ToList();
            Set<ChildObject>().RemoveRange(orphanedEntities);
        }
    }
