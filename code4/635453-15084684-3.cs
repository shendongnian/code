    private IList<string> Load(string tableName, string columnName)
    {
        var result = new List<string>();
        cn.Open();
        OleDbDataReader reader = null;
        OleDbCommand cmd = new OleDbCommand(string.Format("select* from {0}", tableName), cn);
        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            result.Add(reader[columnName].ToString());
        }
        cn.Close();
        return result;
    }
