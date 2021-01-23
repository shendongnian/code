    public static DataTable SqlDataTable(string sql, IDictionary<string, object> values)
    {
        using (SqlConnection conn = new SqlConnection(DatabaseConnectionString))
        using (SqlCommand cmd = conn.CreateCommand())
        {
            conn.Open();
            cmd.CommandText = sql;
            foreach (KeyValuePair<string, object> item in values)
            {
                cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
            }
    
            DataTable table = new DataTable();
            using (var reader = cmd.ExecuteReader())
            {
                table.Load(reader);
                return table;
            }
        }
    }
