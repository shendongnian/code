        while (reader.Read())
        {
            ListViewItem item = new ListViewItem();
            item = new ListViewItem(new[] { 
                reader.GetValue(4).ToString(), // Timestamp
                reader.GetValue(2).ToString() // Log
            });
          items.Add(item);
        }
