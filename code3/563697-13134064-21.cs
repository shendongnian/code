    interface IDb
    {
        bool Execute(string query, Dictionary<string, object> parameters, 
                     out string possibleError);
        DataTable Read(string query, Dictionary<string, object> parameters, 
                       out string possibleError);
        T? ExecuteAndGet<T>(string query, Dictionary<string, object> parameters, 
                            out string possibleError) where T : struct;
    }
    class Db<T> : IDb where T: IDbConnection, new ()
    {
        string _connectionString;
        public Db(string connectionString)
        {
            _connectionString = connectionString;
        }
        S Do<S>(Func<IDbCommand, S> operation, S returnValueInCaseOfError, string query, 
                Dictionary<string, object> parameters, out string possibleError)
        {
            possibleError = null;
            try
            {
                using (var conn = new T())
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
        static void GetParameters(Dictionary<string, object> parameters, T cmd)
        {
            if (parameters == null)
                return;
            foreach (var kvp in parameters)
            {
                var parameter = cmd.CreateParameter();
                parameter.ParameterName = kvp.Key;
                parameter.Value = kvp.Value;
                cmd.Parameters.Add(parameter);
            }
        }
        public bool Execute(string query, Dictionary<string, object> parameters, 
                            out string possibleError)
        {
            return Do(cmd => Execute(cmd), false, query, parameters, 
                      out possibleError);
        }
        static bool Execute(IDbCommand cmd)
        {
            cmd.ExecuteNonQuery();
            return true;
        }
        public DataTable Read(string query, Dictionary<string, object> parameters, 
                              out string possibleError)
        {
            return Do(cmd => Read(cmd), null, query, parameters, 
                      out possibleError);
        }
        static DataTable Read(IDbCommand cmd)
        {
            using (var r = cmd.ExecuteReader())
            {
                var table = new DataTable();
                table.Load(r);
                return table;
            }
        }
        public S? ExecuteAndGet<S>(string query, 
                                   Dictionary<string, object> parameters, 
                                   out string possibleError) where S : struct
        {
            return Do(cmd => ExecuteAndGet<S>(cmd), null, query, parameters, 
                      out possibleError);
        }
        static S? ExecuteAndGet<S>(IDbCommand cmd) where S : struct
        {
            var table = Read(cmd);
            if (table.Rows.Count == 0)
                return default(R); //or your preferred value
            return (S)Convert.ChangeType(table.Rows[0][0], typeof(S));
        }
    }   
