    using (SqlCeConnection connection = new SqlCeConnection(connectionString)
    {
        connection.Open();
        SqlCeCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO <TableName> LastName, FirstName, SortColumn VALUES 'Doe', 'John', '1'";
        command.ExecuteNonQuery();
        connection.Close();
    }
