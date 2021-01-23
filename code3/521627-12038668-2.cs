    public  class DatabaseInitializer : DropCreateDatabaseAlways<PeopleContext>
    {
      protected override void Seed(PeopleContext context)
      {
            context.Database.ExecuteSqlCommand("ALTER TABLE SystemUserAccounts DROP CONSTRAINT uc_User UNIQUE(UserId)"); 
      }
    }
