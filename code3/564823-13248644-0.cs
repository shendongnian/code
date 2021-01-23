    public class UserEntitiesContextInitializer : CreateDatabaseIfNotExists<UserEntitiesContext>
    {
        protected override void Seed(UserEntitiesContext context)
        {
            // Update migration history with existing migrations to prevent EF recognising them as pending migrations
            DatabaseAdministration.UpdateMigrationHistory<UserEntitiesContext, UserEntitiesContextConfiguration>();
        }
    }
    public static void UpdateMigrationHistory<T, TU>()
            where T : DbContext, new()
            where TU : DbMigrationsConfiguration, new()
        {
            using (var dbContext = new T())
            {
                var dbMigrator = new DbMigrator(new TU());
                var creationMigrationId = dbMigrator.GetDatabaseMigrations().Single(m => m.Contains("InitialCreate"));
                
                foreach (var migration in dbMigrator.GetPendingMigrations())
                    dbContext.Database.ExecuteSqlCommand("insert into __MigrationHistory "
                                                            + "select '" + migration + "', Model, ProductVersion "
                                                            + "from __MigrationHistory "
                                                            + "where MigrationId = '" + creationMigrationId + "'");
            }
        }
