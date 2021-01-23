            using (var conn = new SqlConnection(Properties.Settings.Default.DBConnectionString))
            using (var cmd = conn.CreateCommand())
            {
                    conn.Open();
                    cmd.CommandText = "InsertTagProcdure";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Value", Value);
                    cmd.Parameters.AddWithValue("@TagCount", TagCount);
                    cmd.ExecuteNonQuery();
                }
