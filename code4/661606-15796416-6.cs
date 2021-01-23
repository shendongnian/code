    class GumpDatabaseInitializer : CreateAndMigrateDatabaseInitializer<GumpDatabase, YourNamespace.Migrations.Configuration>
    {
        protected override void Seed(GumpDatabase context)
        {
            context.Database.ExecuteSqlCommand("CREATE UNIQUE INDEX Name ON Stations (Name)");
        }
    }
