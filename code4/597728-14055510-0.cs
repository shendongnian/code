    //
    // In a using statement, acquire the SqlConnection as a resource.
    //
    using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["appDSN1"]))
    {
        //
        // Open the SqlConnection.
    		//
        con.Open();
        //
        // The following code shows how you can use an SqlCommand based on the SqlConnection.
        //
        using (SqlCommand command = new SqlCommand("SELECT * FROM Students", con))
        using (SqlDataReader reader = command.ExecuteReader())
        {
    	while (reader.Read())
    	{
              //read through the first database
    	}
        }
    }
    //
    // In a using statement, acquire the SqlConnection as a resource.
    //
    using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["appDSN2"]))
    {
        //
        // Open the SqlConnection.
    		//
        con.Open();
        //
        // The following code shows how you can use an SqlCommand based on the SqlConnection.
        //
        using (SqlCommand command = new SqlCommand("SELECT * FROM employees", con))
        using (SqlDataReader reader = command.ExecuteReader())
        {
    	while (reader.Read())
    	{
              //read through the second database
    	}
        }
