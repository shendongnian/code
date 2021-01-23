    connection = new SqlConnection(strConnect); //connection already defined above
    connection.Open();
    
    SqlCommand command = new SqlCommand(query, connection); 
    command.ExecuteNonQuery();
