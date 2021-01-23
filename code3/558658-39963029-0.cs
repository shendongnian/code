            SqlConnection con = context.Database.Connection as SqlConnection;
            SqlCommand command = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    //read your fields
                }
                
                reader.NextResult();
            }
            con.Close();
            
