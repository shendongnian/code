    public void AddDataToLvw(){
                ListViewItem item1 = new ListViewItem("item1", 0);
                item1.SubItems.Add("1");
                item1.SubItems.Add("3");
    
                ListViewItem item2 = new ListViewItem("item2", 1);
                item2.SubItems.Add("4");
                item2.SubItems.Add("6");
    
                ListViewItem item3 = new ListViewItem("item3", 0);
                item3.SubItems.Add("7");
                item3.SubItems.Add("9");
    
                // Create columns for the items and subitems.
                listView1.Columns.Add("Item Column", -2, HorizontalAlignment.Left);
                listView1.Columns.Add("Column 2", -2, HorizontalAlignment.Left);
                listView1.Columns.Add("Column 3", -2, HorizontalAlignment.Left);
    
                listView1.Items.AddRange(new ListViewItem[] { item1, item2, item3 });
    
    }
