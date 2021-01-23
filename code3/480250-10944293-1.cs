    using (SqlConnection connection= new SqlConnection("CONNECTIONSTRING");
    using (SqlCommand command = new SqlCommand("SELECT-QUERY", connection))
    {
        //set parameters if you need them
        //command.Parameters.AddWithValue("@paramName", paramValue);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        if(reader.Read())
        {
             object date = reader["COLUMNNAME"];
             //Do something with the date...
        }
    }
