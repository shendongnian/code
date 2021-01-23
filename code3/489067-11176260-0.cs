    // store Excel sheet (or any file for that matter) into a SQL Server table
    public void StoreExcelToDatabase(string excelFileName)
    {
        // if file doesn't exist --> terminate (you might want to show a message box or something)
        if (!File.Exists(excelFileName))
        {
           return;
        }
  
        // get all the bytes of the file into memory
        byte[] excelContents = File.ReadAllBytes(excelFileName);
        // define SQL statement to use
        string insertStmt = "INSERT INTO dbo.YourTable(FileName, BinaryContent) VALUES(@FileName, @BinaryContent)";
        // set up connection and command to do INSERT
        using (SqlConnection connection = new SqlConnection("your-connection-string-here"))
        using (SqlCommand cmdInsert = new SqlCommand(insertStmt, connection))
        {
             cmdInsert.Parameters.Add("@FileName", SqlDbType.VarChar, 500).Value = excelFileName;
             cmdInsert.Parameters.Add("@BinaryContent", SqlDbType.VarBinary, int.MaxValue).Value = excelContents;
             // open connection, execute SQL statement, close connection again
             connection.Open();
             cmdInsert.ExecuteNonQuery();
             connection.Close();
        }
    }
