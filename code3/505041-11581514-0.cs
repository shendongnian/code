    using (SqlConnection connection = new SqlConnection(connectionString))  
    {  
        SqlCommand command = connection.CreateCommand();  
      
        command.CommandText = "mysp_GetValue";  
        command.CommandType = CommandType.StoredProcedure;  
      
        connection.Open();  
        object ret = command.ExecuteScalar();  
    }  
