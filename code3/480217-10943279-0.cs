    ConnectionStringSettings settings =
        ConfigurationManager.ConnectionStrings["Punch_Uploader.Properties.Settings.testConnectionString"];
    string connectString = settings.ConnectionString;    
    SqlConnectionStringBuilder builder =
            new SqlConnectionStringBuilder(connectString);
    builder.DataSource = "172.23.2.52:3306";
    builder.InitialCatalog = "test";
    builder.UserID = "root";
    builder.Password = "test123";
