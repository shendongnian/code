        using (var conn = new SqlConnection(connectionString))
        {
            using (var sqlCmd = new SqlCommand("SEL_StoredProcedure", conn))
            {
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //sqlCmd.Parameters.AddWithValue("@ID", Id);
                    sqlCmd.Connection.Open();
                    return cmd.ExecuteScalar() as Int32;
            }
        }
