    public static List<Dictionary<string, object>> GetDataTable(string procName, params SqlParameter[] procParams)
    {
        using (_conn = new SqlConnection(_connStr))
        {
            using (SqlCommand cmd = _conn.CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procName;
    
                if (procParams != null)
                {
                    foreach (SqlParameter p in procParams)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
                _conn.Open();
    
                using (var reader = cmd.ExecuteReader())
                {
                    var result = new List<Dictionary<string, object>>();
    
                    while (reader.Read())
                    {
                        var row = new Dictionary<string, object>();
    
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                           string fieldName = reader.GetName(i);
                           row.Add(fieldName, reader[fieldName]);
                        }
    
                        result.Add(row);
                    }
    
                    return result;
                }
            }
        }
    }
