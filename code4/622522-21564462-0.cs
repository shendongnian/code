    # Migrations/Configuration.cs
	internal sealed class Configuration : DbMigrationsConfiguration<IntranetApplication.Models.MyDb1>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
	}
