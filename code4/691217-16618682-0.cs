	using (SqlCommand command = new SqlCommand("SELECT * FROM YourTable", connection))
	{
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
		   string comments = reader.GetString(4);
           if (comments != null) 
		       Console.WriteLine("Comments is {0}", comments);
           // Assign Text property of your labels..
	    }
	}
