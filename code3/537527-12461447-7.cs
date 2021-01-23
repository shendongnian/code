    public class MyDatabaseContext : DbContext
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
