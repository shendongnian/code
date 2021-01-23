    private static void CreateTables()
    {
        _commandtext = "CREATE TABLE [Users](" +
                        "[ID] Integer PRIMARY KEY, " +
                        "[Username] Text(20), " +
                        "[Password] Text(25), " +
                        "[IBAN] Text(18)" +
                        ");";
        _command = new OleDbCommand(_commandtext, _connection);
        _connection.Open();
        int number = _command.ExecuteNonQuery();  <<< Error
        _connection.Close();
    }
