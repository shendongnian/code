     using (SqlCommand command = new SqlCommand("Select * from tableBooks WHERE @Field LIKE @Value", connection))
    	    {
    		//
    		// Add new SqlParameter to the command.
    		//
    		command.Parameters.Add(new SqlParameter("Field", Textbox1.Text)); // I do not recommend using a textbox and letting the user write anything. You have to limit his choices by the fields in your table. Use a dropdownlist and limit his choices by meaningful fields in your "tableBooks" table.
            command.Parameters.Add(new SqlParameter("Value", Textbox2.Text));
    		//
    		// Read in the SELECT results.
    		//
    		SqlDataReader reader = command.ExecuteReader();
    		while (reader.Read())
    		{
    		    //GET YOUR BOOK
    		}
    	    }
    
