    public  class DatabaseInitializer : DropCreateDatabaseAlways<PeopleContext>
    {
      protected override void Seed(PeopleContext context)
      {
            context.Database.ExecuteSqlCommand("ALTER TABLE SystemUserAccounts ADD CONSTRAINT uc_User UNIQUE(UserId)"); 
      }
    }
