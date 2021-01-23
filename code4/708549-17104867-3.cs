    private void WorkerThread(object transaction)
    {
        OracleTransaction trans = (OracleTransaction) transaction;
        using (OracleCommand command = trans.Connection.CreateCommand())
        {
            command.CommandText = "INSERT INTO mytable (x) values (1)  ";
            command.ExecuteNonQuery();
        }
    }
