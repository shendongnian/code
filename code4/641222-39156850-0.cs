    SqlConnectionStringBuilder connectionBuilderOriginDatabase = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["ORIGIN"].ConnectionString);
    
    ServerConnection originConnection = new ServerConnection(connectionBuilderOriginDatabase.DataSource);
    originConnection.LoginSecure = false;//very important
    originConnection.Login = connectionBuilderOriginDatabase.UserID;
    originConnection.Password = connectionBuilderOriginDatabase.Password;
    
    Server server = new Server(originConnection);
    Database dbMaster = server.Databases[ConfigurationManager.AppSettings.Get("dbMaster")];
    Database dbProduction = server.Databases[ConfigurationManager.AppSettings.Get("dbProduction")];
    Transfer transfer = new Transfer(dbMaster);
    
    string login = ConfigurationManager.AppSettings.Get("login");
    string password = ConfigurationManager.AppSettings.Get("password");
    
    transfer.CopyAllObjects = true;
    transfer.CopyAllUsers = true;
    transfer.Options.WithDependencies = true;
    transfer.Options.ContinueScriptingOnError = true;
    
    //Here you are configuring the destination server
    transfer.DestinationServer = server.Name;
    transfer.DestinationDatabase = dbProduction.Name;
    transfer.DestinationLoginSecure = false;
    transfer.DestinationPassword = password;
    transfer.DestinationLogin = login;
    
    transfer.CopyAllRules = true;
    transfer.CopyAllRoles = true;
    
    //transfer.CopyAllObjects = true;
    
    transfer.DropDestinationObjectsFirst = true;
    transfer.CopySchema = true;
    transfer.CopyData = true;
    transfer.CreateTargetDatabase = false;
    transfer.Options.IncludeIfNotExists = true;
    transfer.Options.Indexes = true;
