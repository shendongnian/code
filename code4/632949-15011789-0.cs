    public partial class YourDBNameDBEntities : DbContext
    {
        public override int SaveChanges()
        {
            foreach (var entry in this.ChangeTracker.Entries<YourTableEntity>().ToList())
            {
                if (entry.State == System.Data.EntityState.Modified)
                {
                    entry.Entity.Rev++;
                }
            }
            return base.SaveChanges();
        }
    }
