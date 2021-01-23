    var sqlConnection = new SqlConnection(DbConnectionStringInternal);
    
    // Bulk-import our unnormalized data from the .csv file into a staging table
    var inputFileConnectionString = String.Format("Driver={{Microsoft Text Driver (*.txt; *.csv)}};Extensions=csv;Readonly=True;Dbq={0}", Path.GetDirectoryName(csvFilePath));
    using (var inputFileConnection = new OdbcConnection(inputFileConnectionString))
    {
        inputFileConnection.Open();
    
        var selectCommandText = String.Format("SELECT * FROM {0}", Path.GetFileName(csvFilePath));
        var selectCommand = new OdbcCommand(selectCommandText, inputFileConnection);
        var inputDataReader = selectCommand.ExecuteReader(CommandBehavior.CloseConnection);
    
        var sqlBulkCopy = new SqlBulkCopy(sqlConnection) { DestinationTableName = "Data_Staging" };    
        if (sqlConnection.State != ConnectionState.Open)
            sqlConnection.Open();
    
        sqlBulkCopy.WriteToServer(inputDataReader);    
    }
    
    // Run a stored-procedure to normalize the data in the staging table, then efficiently move it across to the "real" tables.
    var addDataFromStagingTable = String.Format("EXEC SP_AddDataFromStagingTable");
    if (sqlConnection.State != ConnectionState.Open)
        sqlConnection.Open();
    
    using (var addToStagingTableCommand = new SqlCommand(addDataFromStagingTable, sqlConnection) { CommandTimeout = 60 * 20 })
        addToStagingTableCommand.ExecuteNonQuery();    
    
    sqlConnection.Close();
