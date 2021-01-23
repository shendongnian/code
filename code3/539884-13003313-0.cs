      private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                Database.SetInitializer<WomContext>(null);
                
                // forcing the application of the migrations so the users table is modified before
                // the code below tries to create it. 
                var migrations = new MigrateDatabaseToLatestVersion<WomContext, Wom.Migrations.Configuration>();
                var context = new WomContext(); 
                migrations.InitializeDatabase(context); 
                
                try
                {....
