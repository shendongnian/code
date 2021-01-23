    public class YourContext : DbContext
    {
       ...
       protected override OnModelCreating(DbModelBuilder modelBuilder)
       {
          modelBuilder.Entity<Car>()
             .HasRequired(c => c.Owner)
             .WithMany(p => p.CarsOwned)
             .HasForeignKey(c => c.OwnerId)
             .WillCascadeOnDelete(false);
              // Otherwise you might get a "cascade causes cycles" error
          
          modelBuilder.Entity<Car>()
             .HasRequired(c => c.MainDriver)
             .WithMany() // No reverse navigation property
             .HasForeignKey(c => c.MainDriverId)
             .WillCascadeOnDelete(false);
       }
    }
