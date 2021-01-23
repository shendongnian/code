    class ConnectivityTests
    {
        // Variables
        String serverName = "";
        String databaseName = "";
        String dataSourceName = "";
    
        [Test]
        public void TestDataSourceConnection()
        {
            try
            {
                // Creates an instance of the Server
                Server server = new Server();
                server.Connect(serverName);
                // Gets the Database from the Server
                Database database = server.Databases[databaseName];
                // Get the DataSource from the Database
                DataSource dataSource = database.DataSources.FindByName(dataSourceName);
                // Attempt to open a connection to the dataSource.  Fail test if unsuccessful
                OleDbConnection connection = new OleDbConnection(dataSource.ConnectionString);
                connection.Open();
            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }
            finally
            {
                connection.Close();
            }
         }
    }
