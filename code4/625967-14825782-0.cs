     public class UsersContext : DbContext
        {
            public UsersContext()
                : base("DefaultConnection")
            {
            }
    
            public DbSet<UserProfile> UserProfiles { get; set; }
            public DbSet<RoleModel> Roles { get; set; }
            public DbSet<UsersInRole> UsersInRoles { get; set; }
        }
