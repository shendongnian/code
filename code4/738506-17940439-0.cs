    YourMigrationsConfiguration cfg = new YourMigrationsConfiguration(); 
    cfg.TargetDatabase = 
       new DbConnectionInfo( 
          theConnectionString, 
          "provider" );
    DbMigrator dbMigrator = new DbMigrator( cfg );
    if ( dbMigrator.GetPendingMigrations().Count() > 0 )
    {
       // there are pending migrations
       // do whatever you want, for example
       dbMigrator.Update(); 
    }
