    public class MigrationConfiguration : DbMigrationsConfiguration<UsersContext> 
    {
        public MigrationConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;  // This is important as it will fail in some environments (like Azure) by default
        }
        protected override void Seed(UsersContext context)
        {
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
        }
    }
