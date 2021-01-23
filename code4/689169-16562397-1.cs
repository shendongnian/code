    using (SqlConnection connection = new SqlConnection(connectionString))
            {
               connection.Open();
    
             string queryString = "INSERT INTO merisana1 (sys, dia, pulse) VALUES (@sys, @dia, @pulse)";
               SqlCommand command = new SqlCommand (queryString, connection);        
    
               command.Parameters.AddWithValue("@sys", sys);
               command.Parameters.AddWithValue("@dia", dia);
               command.Parameters.AddWithValue("@pulse", pulse);
    
               command.ExecuteNonQuery();
            }
