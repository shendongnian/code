    public partial class Db<S, T> where S: IDbConnection, new () where T: IDbCommand, new ()
    {
        string _connectionString;
        public Db(string connectionString)
        {
            _connectionString = connectionString;
        }
        public bool Execute(string query, Dictionary<string, object> parameters, out string possibleError)
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
                        GetParameters(parameters, cmd);
                        ExecuteQuery(query, cmd);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                possibleError = ex.Message;
                return false;
            }
        }
        static void ExecuteQuery(string query, T cmd)
        {
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
        }
        public DataTable Read(string query, Dictionary<string, object> parameters, out string possibleError)
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
                        return ReadQuery(cmd);
                    }
                }
            }
            catch (Exception ex)
            {
                possibleError = ex.Message;
                return null;
            }
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
        public R? ExecuteAndGet<R>(string query, Dictionary<string, object> parameters, out string possibleError) 
                                  where R : struct
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
                        var table = ReadQuery(cmd);
                        if (table.Rows.Count == 0)
                            return default(R);
                        return (R)Convert.ChangeType(table.Rows[0][0], typeof(R));
                    }
                }
            }
            catch (Exception ex)
            {
                possibleError = ex.Message;
                return null;
            }
        }
