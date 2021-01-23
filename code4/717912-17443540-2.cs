    {
    String query = "Insert into Employee Values (" + e1.EmpID + ",'" + e1.FirstName + "','" + e1.LastName + "','" + e1.EmailAddress + "', @IMG)";
    
    myCommand = new SQLiteCommand(query, dbConn);
    myCommand.Parameters.Add(new SQLiteParameter("@IMG", e1.Image));
    }
      
