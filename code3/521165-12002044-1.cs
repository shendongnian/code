    internal static long GetNextAutoincrementValue(SQLiteConnection cnn, string tableName)
    {
        long returnValue = -1;
        SQLiteCommand myCommand = cnn.CreateCommand();	
        myCommand.CommandText = @"SELECT [seq] + 1 FROM [sqlite_sequence] WHERE [name] = @MyTableName;";
        SQLiteParameter myParam = new SQLiteParameter("@MyTableName",
            System.Data.DbType.String);
        myParam.Value = tableName.Trim();
        myCommand.Parameters.Add(myParam);
        object resultObj = myCommand.ExecuteScalar();
        myCommand.Dispose();
        if( resultObj != null)
            returnValue = (long)resultObj;
        return returnValue;
    }
