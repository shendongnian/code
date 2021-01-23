    private void Insert(string tableName, Hashtable hash)
    {
        MySqlCommand command = new MySqlCommand();
        List<string> columnList = new List<string>();
        List<string> valueList = new List<string>();
        foreach (DictionaryEntry entry in hash)
        {
            columnList.Add(entry.Key.ToString());
            valueList.Add("@" + entry.Key.ToString());
            command.Parameters.AddWithValue("@" + entry.Key.ToString(), entry.Value);
        }
        command.CommandText = "INSERT INTO " + tableName + "(" + string.Join(", ", columnList.ToArray()) + ") ";
        command.CommandText += "VALUES (" + string.Join(", ", valueList.ToArray()) + ")";
        command.ExecuteScalar();
   }
