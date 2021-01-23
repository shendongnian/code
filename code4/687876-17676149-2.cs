    var connectionString = ((EntityConnection)base.ReferentielContext.Connection).StoreConnection.ConnectionString;
    var builder = new SqlConnectionStringBuilder(connectionString);
    
    var srvConn = new ServerConnection
            {
                ServerInstance = builder.DataSource,
                LoginSecure = false,// set to true for Windows Authentication
                Login = builder.UserID,
                Password = builder.Password
            };
    
    var server = new Microsoft.SqlServer.Management.Smo.Server(srvConn);
