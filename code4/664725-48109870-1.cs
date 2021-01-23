    namespace YourNamespace
    {
    	using System.Data.Entity.Migrations;
    	using System.Data.SQLite.EF6.Migrations;
    
    	internal sealed class Configuration : DbMigrationsConfiguration<YourContext>
        {
            public Configuration()
            {
                AutomaticMigrationsEnabled = false;
    			SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());
            }
    
            protected override void Seed(YourContext context)
            {
                //  This method will be called after migrating to the latest version.
            }
        }
    }
