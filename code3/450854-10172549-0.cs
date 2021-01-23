    using (SqlConnection connection = new SqlConnection(connectionString)) //create connection
    {
    	    connection.Open();//openconnection
    	  
    	    using (SqlCommand command = new SqlCommand("SELECT id, nome, sigla FROM  pais
    WHERE (estado=@estado)", connection)) //create command
    	    {
    		
    		     command.Parameters.Add(new SqlParameter("estado", value)); //add parameter
    		
    		     SqlDataReader reader = command.ExecuteReader(); //execute reader
    		     while (reader.Read())
    		     {
    		         ...... //read the data
    		     }
    	    }
    	}
    }
