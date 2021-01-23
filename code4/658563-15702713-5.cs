    // Create the connection
    using(OleDbConnection con = GetOleDbConnection())
    {
        con.Open();
        ... // use the connection with insert/delete/update/select commands
    }
    // Exiting from the using block close and destroy (dispose) the connection
