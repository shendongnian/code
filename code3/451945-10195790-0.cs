    ListView listView1 = new ListView();
    listView1.View = View.Details;
    
    listView1.Columns.Add("Boat Name", -2, HorizontalAlignment.Left);
    listView1.Columns.Add("Length", -2, HorizontalAlignment.Left);
    listView1.Columns.Add("Sail Size", -2, HorizontalAlignment.Left);
    listView1.Columns.Add("Engines", -2, HorizontalAlignment.Center);
    
    ListViewItem item1 = new ListViewItem(txtBoatName.Text,0);
    item1.SubItems.Add(txtLength.Text);
    item1.SubItems.Add(txtSailSize.Text);
    item1.SubItems.Add(txtEngines.Text);
    
    listView1.Items.Add(item1);
