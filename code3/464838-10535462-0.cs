    //The square brackets contain a valid connection to SQL Server, this is most 
    //easily obtained by linking a table and checking the Connect property
    string ssql = @"INSERT INTO [ODBC;Description=Test;DRIVER=SQL Server;
       SERVER=servername;Trusted_Connection=Yes;
       DATABASE=Test].table_1 (Atext)
       SELECT AText FROM Table1";
    string sourceConnectionString = 
       @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=z:\docs\test.accdb;";
    using (OleDbConnection sourceConnection = new OleDbConnection(sourceConnectionString))
    {
    	OleDbCommand commandSourceData = new OleDbCommand(ssql, sourceConnection);
    	commandSourceData.Connection = sourceConnection;
    	sourceConnection.Open();
    
    	commandSourceData.ExecuteNonQuery();
