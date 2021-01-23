    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConnectionString);
    builder.ConnectTimeout = 10;
    using (var connection = new SqlConnection(builder.ToString()))
    {
        // code goes here
    }
