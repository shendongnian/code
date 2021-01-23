    private SqlConnection GetSqlConnection()
            {
                var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["con1"].ConnectionString);
                sqlConnection.Open();
                return sqlConnection;
            }
    public IEnumerable<T> GetAll<T>(string query, object cmdParams = null, CommandType cmdType = CommandType.Text) where T : class
            {
                IEnumerable<T> objList;
                using (var conn = GetSqlConnection())
                {
                    objList = conn.Query<T>(query, param: cmdParams, commandTimeout:0, commandType: cmdType);
                    conn.Close();
                }
                return objList;
            }
     public IEnumerable<dynamic> Query(string query, object cmdParams = null, CommandType cmdType = CommandType.Text)
            {
                IEnumerable<dynamic> objDyn;
                using (var conn = GetSqlConnection())
                {
                    objDyn = conn.Query(query, cmdParams, commandTimeout: 0, commandType: cmdType);
                    conn.Close();
                }
                return objDyn;
            }
