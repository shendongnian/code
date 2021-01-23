       public class MyDbContext: DbContext
       {
         // Constructor here
    
    
         public DbSet<User> User {get;set;} 
    
         protected override void OnModelCreating(DbModelBuilder modelBuilder)
         {
             modelBuilder.Entity<User>().Map<Man>(c => c.Requires("UserTypeId").HasValue(1));
    
         }
    
    }
