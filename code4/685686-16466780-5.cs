    private IEnumerable<T> GetData(string sql, Action<SqlParameterCollection> addParams, Func<IDataRecord, T> translate)
    {
        using (var cn = new SqlConnection("connection string here"))
        using (var cmd = new SqlCommand(sql, cn))
        {
           addParams(cmd.Parameters);
           cn.Open();
           using (var rdr = cmd.ExecuteReader())
           {
              while (rdr.Read())
              {
                  yield return translate(rdr);
              }
           }
        }
    }
