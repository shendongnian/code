    string tableName = "YourTableName";
    var builder = new SqlCommandBuilder();
    string escapedTableName = builder.QuoteIdentifier(tableName);
    using (var dbCommand = dbConnection.CreateCommand())
    {
        sqlAsk = "";
        sqlAsk += " DELETE FROM " + escapedTableName; //concatenate here
        sqlAsk += " WHERE ImportedFlag = 'F' "; 
        dbCommand.Parameters.Clear();
        dbConnection.Open();
        rowAffected = dbCommand.ExecuteNonQuery();
    }
