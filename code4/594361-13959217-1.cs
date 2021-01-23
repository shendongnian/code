    string connString = 
      ConfigurationMananager.ConnectionStrings["name"].ConnectionString;
    string dbConnectionString = ContextConnectionStringBuilder(connString,
                                                               typeof(MyDbContext));
    var dbContext = new MyDbContext(dbConnectionString);
