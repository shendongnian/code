    using (var myConnection = GetTheConnection())
    {
      myConnection.Open();
      var myCommand = new MySqlCommand("SELECT * FROM table1", myConnection))
      using (var myDataReader = myCommand.ExecuteReader())
      {
        while(myReader.Read())
        {
          //Perform work.
        }
      } // Reader will be Disposed/Closed here
      myCommand.commandText = "SELECT * FROM table2";
      using (var myReader = myCommand.ExecuteReader())
      {
        while(myReader.Read())
        {
          //Perform more work
        }
      } // Reader will be Disposed/Closed here
    } // Connection will be Disposed/Closed here
 
