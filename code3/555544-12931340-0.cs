    var rawStr = Settings.CoreDatabaseConnectionString.ConnectionString;
    // retrieve the original connection string from config file
    var conBuilder = new SqlConnectionStringBuilder(rawStr);
    conBuilder.AttachDBFilename = Path.GetFullPath(
        Path.Combine(Environment.CurrentDirectory, "CoreDatabase.mdf"));
    // if you're doing this in a web environment, swap Environment.CurrentDirectory 
    // for HttpRuntime.AppDomainAppPath
    _sessionFactory = Fluently.Configure()
		.Database(MsSqlConfiguration.MsSql2008
					  .ConnectionString(conBuilder.ToString())
					  .ShowSql()
		)
    // rest of your configuration...
    
