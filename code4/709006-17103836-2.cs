    public List<ListViewItem> SQL_GetLogsHistory(string WKS)
    {
        List<ListViewItem> items = new List<ListViewItem>();
        using (SqlCommand mySQLCommand = new SqlCommand(Properties.Settings.Default.SQL_GetLogsHistroy, SQLconn))
        {
            mySQLCommand.Parameters.AddWithValue("@WKS", WKS);
            using (SqlDataReader reader = mySQLCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    ListViewItem item =  new ListViewItem(new[] { 
                                reader.GetValue(4).ToString(), // Timestamp
                                reader.GetValue(2).ToString() // Log
                            });
                    items.Add(item);
                }
            }
    
        }
        return items;
    }
