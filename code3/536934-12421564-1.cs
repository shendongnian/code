    public string QueryResult(string query)
    {
        string result = "";
        SQLiteConnection sqlite = new SQLiteConnection("Data Source=/path/to/file.db");
        try
        {
            sqlite.Open();  //Initiate connection to the db
            SQLiteCommand cmd = sqlite.CreateCommand();
            cmd.CommandText = query;  //set the passed query
            result = cmd.ExecuteScalar().ToString();
        }
        finally
        {
            sqlite.Close();
        }
        return result;
    }
