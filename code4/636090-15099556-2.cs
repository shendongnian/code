    public int ExecuteNonQuery(string sql)
    {
        var cnn = new SQLiteConnection(_dbConnection);
        cnn.Open();
        var transaction = cnn.BeginTransaction();
        var mycommand = new SQLiteCommand(cnn) {CommandText = sql};
        mycommand.Transaction = transaction;
        int rowsUpdated = mycommand.ExecuteNonQuery();
        transaction.Commit();
        cnn.Close();
        return rowsUpdated;
    }
