    private static void InitializeDataStore()
    {
      System.Data.Entity.Database.SetInitializer(new System.Data.Entity.MigrateDatabaseToLatestVersion<GalleryDb, GalleryDbMigrationConfiguration>());
      var configuration = new GalleryDbMigrationConfiguration();
      var migrator = new System.Data.Entity.Migrations.DbMigrator(configuration);
      if (migrator.GetPendingMigrations().Any())
      {
        migrator.Update();
      }
    }
    public sealed class GalleryDbMigrationConfiguration : DbMigrationsConfiguration<GalleryDb>
    {
      protected override void Seed(GalleryDb ctx)
      {
        MigrateController.ApplyDbUpdates();
      }
    }
