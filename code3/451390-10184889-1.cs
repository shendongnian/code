    public double GetBal()
    {
      // Make sure you change this to a real userID that you pass in.
      var query = "SELECT Users.Money FROM Users WHERE Users.UserID = 1";
      double balance = 0;
  
      using (var dbconn = new OleDbConnection(connectionString)) {
        var command = new OleDbCommand(query, dbconn);
        dbconn.Open();
        // Send the command (query) to the connection, creating an
        // OleDbReader in the process. We want it to close the database
        // connection in the process so we pass in that behavior as an
        // argument (CommandBehavior.CloseConnection)
        var myReader = command.ExecuteReader(CommandBehavior.CloseConnection);
        // this while loop will keep executing until there are no more rows
        // to read from the database. myReader.Read() moves to the next row
        // in the database too. The first read() puts you at the first row.
        while(myReader.Read()) 
        {
            // Use the reader's GetDouble() method to read the data and convert
            // it to a double. The 0 is there because it is the first column in
            // the results. for example to read the third column, it would be
            // myReader.GetDouble(2).
            balance = myReader.GetDouble(0));
        }
        // because there is only one row (query said where Users.UserID = 1) the
        // above loop will only execute once.
        // Close the reader so we can tell the command that the connection
        // can be closed...because CommandBehavior.CloseConnection was specified
        myReader.Close();
      }
    
      // return the value we got from the database
      return balance
    }
