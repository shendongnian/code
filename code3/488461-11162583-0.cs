    //Call the instance
    dbConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.4.0;Data Source=Y:\\\\serverName\\Share\\document.xls;Extended Properties='Excel 12.0 Xml;HDR=YES'");
    dbCommand = new OleDbCommand("SELECT * FROM TableName", dbConnection);
    dbAdapter = new OleDbDataAdapter(sql, dbConnection);
    dataTable = new DataTable();
    dbConnection.Open();
    dbReader = dbCommand.ExecuteReader();
