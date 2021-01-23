    public List<ListViewItem> SQL_GetLogsHistory(string WKS)
    {
        SqlCommand mySQLCommand = new SqlCommand(Properties.Settings.Default.SQL_GetLogsHistroy, SQLconn);
        mySQLCommand.Parameters.AddWithValue("@WKS", WKS);
        SqlDataReader reader = mySQLCommand.ExecuteReader();
        List<ListViewItem> items = new List<ListViewItem>();
        while (reader.Read())
        {
            var item = new ListViewItem(new[] { 
                reader.GetValue(4).ToString(), // Timestamp
                reader.GetValue(2).ToString() // Log
            });
			
			items.Add(item);
        }
        reader.Close();
        return items;
    }
