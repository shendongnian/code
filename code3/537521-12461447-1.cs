    public class MyDatabaseInit: DropCreateDatabaseAlways<MyDatabaseContext>
    {
        protected override void Seed(MyDatabaseContext context)
        {
            SeedMembership();
        }
        private void SeedMembership()
        {
            WebSecurity.InitializeDatabaseConnection("MyDatabaseContext",
                "UserProfile", "UserId", "UserName", autoCreateTables: true);
        } 
    }
