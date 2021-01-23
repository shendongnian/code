    public class MyContext : DbContext
    {
        // ...........
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subscription>().HasRequired()
               .WithOptional(a => a.Subscriptions);
        }
    }
