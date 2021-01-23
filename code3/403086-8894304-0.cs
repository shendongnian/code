    string sql= "Build you query";
        using (SqlConnection connection = new SqlConnection(
                   "your connectionstring"))
        {
            SqlCommand command = new SqlCommand(
                sql, connection);
            connection.Open();
            
           
            command.ExecuteNonQuery();
            
            reader.Close();
            
        }
