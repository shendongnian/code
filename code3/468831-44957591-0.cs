        private static void InitializeDataStore()
        {
            System.Data.Entity.Database.SetInitializer(new System.Data.Entity.MigrateDatabaseToLatestVersion<GalleryDb, GalleryDbMigrationConfiguration>());
            System.Data.Entity.Database.Initialize(false);
        }
