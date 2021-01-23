            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("RetriveEmailData", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@email", SqlDbType.Varchar).Value = email;            
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
                {                  
                   userName += dr["firma"].ToString();
                }
            dr.Close();
            conn.Close();
