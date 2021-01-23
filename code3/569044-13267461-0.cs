    OdbcConnection connection;
    SqlBulkCopy bulkCopy;
    string ConnectionString = @"server=hostname\sqlexpress;database=pubs;uid=sa;pwd=1234;";
    string connstr = @"Driver={Microsoft Excel Driver (*.xls)};DriverId=790;Dbq=c:\contact.xls";
    using (connection = new OdbcConnection(connstr))
    {
    
    OdbcCommand command = new OdbcCommand("Select * FROM [Sheet1$]", connection);
    
    //you can change [Sheet1$] with your sheet name
    connection.Open();
    
    // Create DbDataReader to Data Worksheet
    
    using (OdbcDataReader dr = command.ExecuteReader())
    
    {
    
    // Bulk Copy to SQL Server
    
    
    
    using (bulkCopy = new SqlBulkCopy(ConnectionString))
    {
    
    bulkCopy.DestinationTableName = "Names";
    //"Names" is the sql table where you want to copy all data
    bulkCopy.WriteToServer(dr);
    }
    dr.Close();
    }
    }
    
    bulkCopy.Close();
