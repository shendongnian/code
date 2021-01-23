    interface IDb
    {
        bool Execute(string query, Dictionary<string, object> parameters, 
                     out string possibleError);
        DataTable Read(string query, Dictionary<string, object> parameters, 
                       out string possibleError);
        R? ExecuteAndGet<R>(string query, Dictionary<string, object> parameters, 
                            out string possibleError) where R : struct;
    }
    class Db<S, T> : IDb where S: IDbConnection, new () where T: IDbCommand, new ()
    {
        string _connectionString;
        public Db(string connectionString)
        {
            _connectionString = connectionString;
        }
        R Do<R>(Func<T, R> operation, R returnValueInCaseOfError, string query, 
                Dictionary<string, object> parameters, out string possibleError)
        {
            possibleError = null;
            try
            {
                using (var conn = new S())
                {
                    conn.ConnectionString = _connectionString;
                    conn.Open();
                    using (var cmd = new T())
                    {
                        cmd.Connection = conn;
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
            return Do(cmd => ExecuteQuery(cmd), false, query, parameters, 
                      out possibleError);
        }
        static bool ExecuteQuery(T cmd)
        {
            cmd.ExecuteNonQuery();
            return true;
        }
        public DataTable Read(string query, Dictionary<string, object> parameters, 
                              out string possibleError)
        {
            return Do(cmd => ReadQuery(cmd), null, query, parameters, 
                      out possibleError);
        }
        static DataTable ReadQuery(T cmd)
        {
            using (var r = cmd.ExecuteReader())
            {
                var table = new DataTable();
                table.Load(r);
                return table;
            }
        }
        public R? ExecuteAndGet<R>(string query, 
                                   Dictionary<string, object> parameters, 
                                   out string possibleError) where R : struct
        {
            return Do(cmd => ExecuteAndGetQuery<R>(cmd), null, query, parameters, 
                      out possibleError);
        }
        static R? ExecuteAndGetQuery<R>(T cmd) where R : struct
        {
            DataTable dt = ReadQuery(cmd);
            if (dt.Rows.Count == 0)
                return default(R); //or your preferred value
            return (R)Convert.ChangeType(dt.Rows[0][0], typeof(R));
        }
    }   
