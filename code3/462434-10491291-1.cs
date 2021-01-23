    class DbInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            context.Database.ExecuteSqlCommand("ALTER TABLE Addresses ADD CONSTRAINT uc_User UNIQUE(UserId)");
        }
    }
