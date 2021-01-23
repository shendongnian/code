    private void UpdateRecord(string connectionString)
    {
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand("UPDATE Sifrant SET cena = 1.1 WHERE ID = 2", connection);
            command.ExecuteNonQuery();
        }
    }
