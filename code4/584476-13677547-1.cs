    SqlConnection connection = new SqlConnection();
    SqlCommand command = new SqlCommand();
    connection.ConnectionString = connectionString; // put your connection string
    command.CommandText = @"
         update table
         set somecol = somevalue;
         insert into someTable values(1,'test');";
    command.CommandType = CommandType.Text;
    command.Connection = connection;
    
    try
    {
        connection.Open();
    }
    finally
    {
        command.Dispose();
        connection.Dispose();
    }
