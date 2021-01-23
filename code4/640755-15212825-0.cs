    static IEnumerable<T> ExecuteQuery<T>(string sql, dynamic param, string cnnString)
        where T : BaseModel
    {
        using (var conn = DataAccessHelpers.GetOpenConnection(cnnString))
        {
            return SqlMapper.Query(conn, sql, param).ToList<T>();
        }
    }
