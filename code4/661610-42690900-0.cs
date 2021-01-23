    public class CreateOrMigrateDatabaseInitializer<TContext, TConfiguration> : CreateDatabaseIfNotExists<TContext>, IDatabaseInitializer<TContext>
            where TContext : DbContext
            where TConfiguration : DbMigrationsConfiguration<TContext>, new()
        {
            void IDatabaseInitializer<TContext>.InitializeDatabase(TContext context)
            {
                if (context.Database.Exists())
                {
                    if (!context.Database.CompatibleWithModel(throwIfNoMetadata: false))
                    {
                        var migrationInitializer = new MigrateDatabaseToLatestVersion<TContext, TConfiguration>(true);
                        migrationInitializer.InitializeDatabase(context);
                    }
                }
                base.InitializeDatabase(context);
            }
        }
