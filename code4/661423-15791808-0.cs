         public class UsersContext : DbContext
         {
             public UsersContext()
               : base("UsersContext")
             {
             }
    
              public DbSet<UserProfile> UserProfiles { get; set; }
         }
