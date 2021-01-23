    public class YourDbInitializer : DropCreateDatabaseIfModelChanges<YourDbContext>
    {
        protected override void Seed(DiorContextBase context)
        {
            context.Database.ExecuteSqlCommand(
                    "CREATE UNIQUE NONCLUSTERED INDEX Username_Unique " +
                    "ON dbo.Users(username)");
        }
    }
