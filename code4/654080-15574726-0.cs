    List<Dictionary<string, string>> allResults = new List<Dictionary<string, string>>();
    MySqlCommand cmd = new MySqlCommand(query, conn);
    MySqlDataReader dataReader = cmd.ExecuteReader();
    try
    {
        while (dataReader.Read())
        {
            Dictionary<string, string> selectResult = new Dictionary<string, string>();
            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                selectResult.Add(dataReader.GetName(i).ToString(), dataReader.GetValue(i).ToString());
            }
            allResults.Add(selectResult);
        }
        dataReader.Close();
    }
    //...
