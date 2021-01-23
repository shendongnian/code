    public class MyContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
             modelBuilder.Entity<Address>()
                 .HasRerquired(a => a.User)
                 .WithOptional(u => u.Address);
        }
    }
