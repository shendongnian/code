            string[] exampleData = { "1", "2", "3" };
            string[] namesToSortBy = { "Sam", "Bill", "Jeff" };
            SortedList<string, ListViewItem> alphabetical = new SortedList<string, ListViewItem>();
            for (int i = 0; i < exampleData.Length; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = exampleData[i];
                lvi.SubItems.Add(namesToSortBy[i]);
                alphabetical.Add(namesToSortBy[i], lvi);
            }
            foreach (KeyValuePair<string, ListViewItem> item in alphabetical)
            {
                listView1.Items.Add(item.Value);
            }
