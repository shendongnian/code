    public class OAuthNoMigrateInitializer : DropCreateDatabaseAlways<OAuthNoMigrateContext>
    {
        private readonly CustomSimpleMembershipProvider _provider = new CustomSimpleMembershipProvider();
        protected override sealed void Seed(OAuthNoMigrateContext context)
        {
            //Initialize UserProfile
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
            AddUsers(context);
        }
        private void AddUsers(OAuthNoMigrateContext context)
        {
            if (WebSecurity.UserExists("username")) return;
            var user = new User
            {
                FirstName = "FName",
                LastName = "LName"
            };
            _provider.CreateUser("username", "password", user);
        }
    }
