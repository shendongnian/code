       public IEnumerable<ListViewItem> SQL_GetLogsHistory(string WKS)
        {
            SqlCommand mySQLCommand = new SqlCommand(Properties.Settings.Default.SQL_GetLogsHistroy, SQLconn);
            mySQLCommand.Parameters.AddWithValue("@WKS", WKS);
            SqlDataReader reader = mySQLCommand.ExecuteReader();
            ListViewItem item = new ListViewItem();
    
    
            while (reader.Read())
            {
                yield return new ListViewItem(new[] { 
    
                    reader.GetValue(4).ToString(), // Timestamp
                    reader.GetValue(2).ToString() // Log
    
                });
    
            }
    
            reader.Close();
            return item;
        }
