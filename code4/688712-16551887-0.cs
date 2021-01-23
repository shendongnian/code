    // by name attribute from the app.config/web.config
    ConfigurationManager.ConnectionStrings["networkingEntities"].ConnectionString; connection string.
    // or select by index.
    var index = 0;
    var adminConnectionString = ConfigurationManager.ConntectionString[++index];
    var userConnectionString = ConfigurationManager.ConnectionString[index];
   
