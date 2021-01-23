    void Read_My_Excel_File()
    {
    
    // Test.xls is in the C:\
    
    string connectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + C:\Test.xls + ";";
    
    connectionString += "Extended Properties=Excel 8.0;";
    
    // always read from the sheet1.
    OleDbCommand myCommand = new OleDbCommand("Select * from [Sheet1$];");
    OleDbConnection myConnection = new OleDbConnection(connectionString);
    myConnection.Open();
    myCommand.Connection = myConnection;
    OleDbDataReader myReader = myCommand.ExecuteReader();
    while (myReader.Read())
    {
    
    // it can read upto 5 columns means A to E. In your case if the requirement is different then change the loop limits a/c to it.
    
    for (int i = 0; i < 5; i++)
    {
      Response.Write(myReaderIdea.ToString() + " ");
    }
    Response.Write("<br>");
    }
    myConnection.Close();
    }
