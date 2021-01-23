        public static void DeleteSomething()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_proc_delete", conn.CreateCommand()))
                {
                     conn.Open()
                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Parameters.AddWithValue("@PrimaryKey", SqlDbType.Int);
                     cmd.ExecuteNonQuery();
                }
            }
        }
