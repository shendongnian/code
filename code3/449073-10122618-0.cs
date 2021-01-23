    public class MyContext : DbContext
    {
        //...
    
        public override int SaveChanges()
        {
            foreach (var dbEntityEntry in ChangeTracker.Entries<AbstractModel>())
            {
                dbEntityEntry.Entity.UpdateDates();
            }
            return base.SaveChanges();
    
        }
    }
