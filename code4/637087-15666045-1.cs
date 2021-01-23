    public class OAuthNoMigrateContext : DbContext
    {
        public OAuthNoMigrateContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
