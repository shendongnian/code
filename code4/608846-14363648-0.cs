    public string SqlConnection(string queryString)
        {
            using (var conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["RBConnectionString"].ConnectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = queryString;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // This will return the first result 
                        // but there might be other
                        return reader.GetString(0);
                    }
                }
                return null;
            }
        }
