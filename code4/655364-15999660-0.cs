    public virtual IEnumerable<dynamic> Query(string sql, params object[] args)
    {
        using (var conn = OpenConnection())
        {
            using (var rdr = CreateCommand(sql, conn, args).ExecuteReader())
            {
                while (rdr.Read())
                {
                    yield return rdr.RecordToExpando(); ;
                }
            }
        }
    }
