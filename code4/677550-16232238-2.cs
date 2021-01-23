    using System.Data.Entity.Migrations;
    internal sealed class Configuration : DbMigrationsConfiguration<DatabaseContext>
    {
	    public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }
        protected override void Seed(DatabaseContext context)
        {
        }
    }
