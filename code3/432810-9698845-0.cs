    using (SqlConnection connection = new SqlConnection("connectionString"))
    using (SqlCommand command = new SqlCommand("SELECT * FROM Users", connection))
    {
    	// Do something here...
    }
