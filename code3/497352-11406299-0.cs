            // Dictinary DataSource containing data to be filled in the ListView
            Dictionary<string, List<string>> Values = new Dictionary<string, List<string>>()
            {
                { "val1", new List<string>(){ "val1a", "val1b" } },
                { "val2", new List<string>(){ "val2a", "val2b" } },
                { "val3", new List<string>(){ "val3a", "val3b" } }
            };
            // ListView to be filled with the Data
            ListView listView = new ListView();
            // Iterate through Dictionary and fill up the ListView
            foreach (string key in Values.Keys)
            {
                // Fill item
                ListViewItem item = new ListViewItem(key);
                // Fill Sub Items
                List<string> list = Values[key];
                item.SubItems.AddRange(list.ToArray<string>());
                // Add to the ListView
                listView.Items.Add(item);
            }
