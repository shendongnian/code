    var connection = new SqlConnection("...");//You can adjust your string connection
    var adapter = new SqlDataAdapter();
    // Create the SelectCommand.
    var command = new SqlCommand("YourSelectStoredProcedure", connection); //You can adjust your name of stored procedure
    command.CommandType = CommandType.StoredProcedure;
    adapter.SelectCommand = command;
    // Create the InsertCommand.
    command = new SqlCommand("YourInsertStoredProcedure", connection); //You can adjust your name of stored procedure
    command.CommandType = CommandType.StoredProcedure;
    adapter.InsertCommand = command;
