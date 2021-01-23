    public class YourDBCOntext:DbContext
    {
      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
         modelBuilder.Conventions.Remove<PluralizingTaleNameConvention>();
      }    
    }
