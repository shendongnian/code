    public class DbHepler
        {
            private readonly string _connectionString;
            public DbHepler(string connectionString)
            {
                _connectionString = connectionString;
            }
    
            public void ExecuteNonQuery(string query)
            {
                ExecuteNonQuery(query, null);
            }
    
            public void ExecuteNonQuery(string query, Dictionary<string, object> parameters)
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
    
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = query;
    
                        if (parameters != null)
                        {
                            foreach (string parameter in parameters.Keys)
                            {
                                cmd.Parameters.AddWithValue(parameter, parameters[parameter] ?? DBNull.Value);
                            }
                        }
    
                        cmd.ExecuteNonQuery();
                    }
    
                    conn.Close();
                }
            }
        }
