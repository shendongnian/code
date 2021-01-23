    public bool Add(string example)
        {
            try
            {
                
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("[Proc name]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    cmd.Parameters.AddWithValue("@Example", example);
                    
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
