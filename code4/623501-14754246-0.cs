        using (SqlConnection connection = new SqlConnection(connectionString))
       {
    	   // Connect to the database then retrieve the schema information.
    	   connection.Open();
    	   DataTable table = connection.GetSchema("Tables");
    		..
    		..
    		..
