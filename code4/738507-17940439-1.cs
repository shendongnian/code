    YourMigrationsConfiguration cfg = new YourMigrationsConfiguration(); 
    cfg.TargetDatabase = 
       new DbConnectionInfo( 
          theConnectionString, 
          "provider" );
    DbMigrator dbMigrator = new DbMigrator( cfg );
    if ( dbMigrator.GetPendingMigrations().Any() )
    {
       // there are pending migrations
       // do whatever you want, for example
       dbMigrator.Update(); 
    }
