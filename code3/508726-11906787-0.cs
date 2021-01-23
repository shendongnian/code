    namespace MyProject.Data.DatabaseInitializers
    {
        public class MyCustomDbInit<TContext> : IDatabaseInitializer<TContext>
            where TContext : DbContext
        {
            public void InitializeDatabase(TContext context)
            {
                // Create our database if it doesn't already exist.
                context.Database.CreateIfNotExists()
                // Do you want to migrate to latest in your initializer? Add code here!
                // Do you want to seed data in your initializer? Add code here!
            }
        }
    }
