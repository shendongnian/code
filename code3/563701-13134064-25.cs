    class Db
    {
        string _connectionString;
        DbProviderFactory _factory;
        public Db(string driver, string connectionString)
        {
            _factory = DbProviderFactories.GetFactory(driver);
            _connectionString = connectionString;
        }
        //and your core function would look like
        S Do<S>(Func<IDbCommand, S> operation, S returnValueInCaseOfError, string query, 
                Dictionary<string, object> parameters, out string possibleError)
        {
            possibleError = null;
            try
            {
                using (var conn = factory.CreateConnection())
                {
                    conn.ConnectionString = _connectionString;
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = query;
                        GetParameters(parameters, cmd);
                        return operation(cmd);
                    }
                }
            }
            catch (Exception ex)
            {
                possibleError = ex.Message;
                return returnValueInCaseOfError;
            }
        }
        //and the remaining code..
    }
