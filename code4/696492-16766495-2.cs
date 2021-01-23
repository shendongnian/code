       public class MyDbContext: DbContext
       {
         // Constructor here
    
    
         public DbSet<Man> Man {get;set;} 
    
         protected override void OnModelCreating(DbModelBuilder modelBuilder)
         {
             modelBuilder.Entity<Man>().Map<User>(c => c.Requires("UserTypeId").HasValue(1));
    
         }
    
    }
