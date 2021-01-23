    public static IEnumerable<IDataRecord> GetData(string command, Action<SqlParameterCollection> addParameters)
    {
        using (var cn = new SqlConnection( /* generic code for connection string here */ ));
        using (var cmd = new SqlCommand(command, cn))
        {
            addParameters(cmd.Parameters);
            cn.Open();
            using (var rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    yield return rdr;
                }
            }
        }
    }
