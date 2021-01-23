    public class UsersContext : DbContext
    {
        public UsersContext() : base("DefaultConnection")
        {
        }
        public DbSet<UserProfile> UserProfiles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
