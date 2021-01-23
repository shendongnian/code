    public class YourDBCOntext:DbContext
    {
      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
        modelBuilder.Entity<Applications>().ToTable("MYApplications");
      }    
    }
