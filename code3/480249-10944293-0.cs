    SqlConnection conn = new SqlConnection("CONNECTIONSTRING");
    using(SqlCommand command = new SqlCommand("SELECT-QUERY", conn))
    {
    //set parameters if you need them
    using(SqlDataReader reader = command.ExecuteReader())
    {
    if(reader.Read())
    {
    object date = reader["COLUMNNAME"];
    //Do something with the date...
    }    
    }
    }
