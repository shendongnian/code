    public double GetBal()
    {
        // Make sure you change this to a real userID that you pass in.
        var query = "SELECT Users.Money FROM Users WHERE Users.UserID = 1";
        var dbconn = new OleDbConnection(connection);
        var command = new OleDbCommand(query, dbconn);
        dbconn.Open();
        double balance = 0;
        try
        {
            command.ExecuteReader(CommandBehavior.CloseConnection);
            while(myReader.Read()) 
            {
                balance = myReader.GetDouble(0));
            }
            myReader.Close();
        }
        catch (OleDbException ex)
        {
        }
        finally
        {
            dbconn.Close();
        }
        return balance
    }
