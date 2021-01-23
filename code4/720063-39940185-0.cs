    using Oracle.ManagedDataAccess.Client;
    private static void CheckConnectionUsingOracleClient(string connection)
            {
                var logger = DiContainer.Resolve<ILogger>();
    
                try
                {
                    logger.LogInfo("Trying to connect to " + connection);
                    // check whether you can connect to the shop using Oracle.DataAccess
                    using (var cnn = new OracleConnection(connection))
                    {
                        cnn.Open();
                        cnn.Close();
                    }
    
                    logger.LogInfo("Succeeded to connect to " + connection);
                }
                catch (System.Exception ex)
                {
                    logger.LogError("Failed to connect to " + connection, ex);
                }
            }
