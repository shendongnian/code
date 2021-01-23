      // Select using a Named Range
      //string selectString = "SELECT * FROM Customers";
 
      // Select using a Worksheet name
      string selectString = "SELECT * FROM [Sheet1$]";
 
      OleDbConnection con = new OleDbConnection(connectionString);
      OleDbCommand cmd = new OleDbCommand(selectString,con);
 
      try
      {
        con.Open();
        OleDbDataReader theData = cmd.ExecuteReader();
        while (theData.Read())
        {
          Console.WriteLine("{0}: {1} ({2}) - {3} ({4})", theData.GetString(0),theData.GetString(1),theData.GetString(2),theData.GetString(3),theData.GetString(4));
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      finally
      {
        con.Dispose();
      }
    
