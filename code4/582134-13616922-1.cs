    var connectString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
    
    var stringBuilder = new SqlConnectionStringBuilder(connectString);
    
    string UserID = stringBuilder.UserID;
    string Password = stringBuilder.Password;
    string catalog = stringBuilder.InitialCatalog;
