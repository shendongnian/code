        internal sealed class Configuration : DbMigrationsConfiguration<YourApplication.Database.Context>
        {
            public Configuration()
            {
                // I recommend that auto-migrations be disabled so that we control
                // the migrations explicitly 
                AutomaticMigrationsEnabled = false;
                CodeGenerator = new EFExtensions.CustomCodeGenerator();
            }
            protected override void Seed(YourApplication.Database.Context context)
            {
                //   Your custom seed logic here
            }
        }
