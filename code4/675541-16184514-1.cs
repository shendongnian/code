    using (SqlConnection connection = new SqlConnection(connectionString))
    {
       connection.Open();
       using (SqlCommand command = new SqlCommand("SELECT fligth_id FROM flight_info WHERE  depart_from = @depart AND destination = @destination", connection))
       {
            command.Parameters.Add("@depart", depart);
            command.Parameters.Add("@destination", destination);
    	    SqlDataReader myReader = command.ExecuteReader();
    	    while (myReader.Read())
    	    {
    		   int fligth_id = reader.GetInt32(0);
    	    }
       }
    }
