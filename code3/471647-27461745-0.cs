    private DataSet executeDataQuery(string query, string connection, string provider, out Exception ex) {
            DataSet ds = new DataSet();
            ex = null;
            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(provider);
            IDbConnection dbConnection = dbFactory.CreateConnection();
            dbConnection.ConnectionString = connection;
            using (dbConnection) {
                try {
                    IDbDataAdapter dbAdapter = dbFactory.CreateDataAdapter();
                    IDbCommand dbCommand = dbConnection.CreateCommand();
                    dbCommand.CommandText = query;
                    dbCommand.CommandType = CommandType.Text;
                    dbAdapter.SelectCommand = dbCommand;
                    dbAdapter.Fill(ds);
                }
                catch (Exception exc) {
                    ex = exc;
                }
                finally {
                    if (dbConnection.State == ConnectionState.Open) {
                        dbConnection.Close();
                    }
                }
            }
            return ds;
        }
