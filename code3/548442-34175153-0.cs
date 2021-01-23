    ConnectionInfo connection = new ConnectionInfo();
    string connectionString = ConfigurationManager.ConnectionStrings["_2Focus.Properties.Settings._2ServeConnection"].ConnectionString;
    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
    connection.ServerName = builder.DataSource;
    connection.DatabaseName = builder.InitialCatalog;
    connection.IntegratedSecurity = builder.IntegratedSecurity;
    if (!builder.IntegratedSecurity)
    {
        connection.Password = builder.Password;
        connection.UserID = builder.UserID;
    }
    Tables CrTables = report.Database.Tables 
    foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
    {
        CrTable.LogOnInfo.ConnectionInfo = connection;
        CrTable.ApplyLogOnInfo(CrTable.LogOnInfo);
    } 
