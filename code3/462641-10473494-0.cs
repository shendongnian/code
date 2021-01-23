    public static IDbConnection GetConnection(string connectionName)
        {
          ConnectionStringSettings ConnectString = ConfigurationManager.ConnectionStrings[connectionName];
    //Use a Factory class, to which you pass the ProviderName and 
    //it will return you object for that particular provider, you will have to implement it
          DbProviderFactory Factory = DbProviderFactories.GetFactory(ConnectString.ProviderName);
          IDbConnection Connection = Factory.CreateConnection();
          Connection.ConnectionString = ConnectString.ConnectionString;
          return Connection;
        }
