        String connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelFilePath + ";Extended Properties=Excel 12.0;";
        // Create connection object by using the preceding connection string.
        OleDbConnection objConn = new OleDbConnection(connString);
        // Open connection with the database.
        objConn.Open();
