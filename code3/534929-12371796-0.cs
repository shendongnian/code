      Dictionary<string, int> itemsSource = new Dictionary<string, int>() { { "Board", 1 }, { "Messages Transmitted", 75877814 }, {"ISR Count", 682900312}, {"Bus Errors", 0}, {"Data Errors", 0}};
        foreach (var item in itemsSource)
        { 
            ListViewItem listItem = new ListViewItem(item.Key);
            listItem.SubItems.Add(item.Value.ToString());
            listView1.Items.Add(listItem);
        }
