        OleDbCommand myCommand = new OleDbCommand("Select * from [Sheet1$];");
        OleDbConnection myConnection = new OleDbConnection(connectionString);
        myConnection.Open();
        myCommand.Connection = myConnection;
        OleDbDataReader myReader = myCommand.ExecuteReader();
    
        while (myReader.Read())
        {
        // it can read upto 5 columns means A to E. In your case if the requirement is different then change the loop limits a/c to it.
          //Change the Response.Write blow to Console.WriteLine() if you are wanting to test this in a Console application vs a web app.
          for (int i = 0; i < 5; i++)
          {
            Response.Write(myReaderIdea.ToString() + " ");
          }
          Response.Write("<br>");
        }
        myConnection.Close();
        
        //make sure to Dispose of the Reader object as well 
       ((IDisposable)myReaderIdea).Dispose();
