    string connectionString = "Provider=Search.CollatorDSO;Extended Properties=\"Application=Windows\"";
    OleDbConnection connection = new OleDbConnection(connectionString);
    string query = @"SELECT System.ItemName FROM SystemIndex " +
       @"WHERE scope ='file:" + System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "' and FREETEXT('dummy')";
    OleDbCommand command = new OleDbCommand(query, connection);
    connection.Open();
    List<string> result = new List<string>();
    OleDbDataReader reader = command.ExecuteReader();
    while (reader.Read())
    {
        result.Add(reader.GetString(0));
    }
    connection.Close();
