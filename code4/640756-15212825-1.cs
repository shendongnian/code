    static IEnumerable<T> ExecuteQuery<T>(string sql, dynamic param, string connStr)
        where T : BaseModel
    {
        using (var conn = DataAccessHelpers.GetOpenConnection(connStr))
        {
            return SqlMapper.Query(conn, sql, param).ToList<T>();
        }
    }
