    var connectionString = "DRIVER={MySQL ODBC 3.51 Driver};" +
                         "SERVER=localhost;" +
                         "DATABASE=test;" +
                         "UID=venu;" +
                         "PASSWORD=venu;" +
                         "OPTION=3");
    using (OdbcConnection connection = new OdbcConnection(connectionString))
    {
        OdbcCommand command = new OdbcCommand("SELECT email, name FROM mytable WHERE id=7", connection);
        connection.Open();
        // Execute the DataReader and access the data.
        OdbcDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            //do stuff with the data here row by row the reader is a cursor
        }
        // Call Close when done reading.
        reader.Close();
