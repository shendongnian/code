    private static List<Dictionary<string, object>> LoadData(string sqlSelect, params object[] sqlParameters)
    {
        var table = new List<Dictionary<string, object>>();
        using (var ctx = new DbEntities())
        {
            ctx.Database.Connection.Open();
            using (var cmd = ctx.Database.Connection.CreateCommand())
            {
                cmd.CommandText = sqlSelect;
                foreach (var param in sqlParameters)
                    cmd.Parameters.Add(param);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var row = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                            row[reader.GetName(i)] = reader[i];
                        table.Add(row);
                    }
                }
            }
        }
        return table;
    }
