    // You can either set the columns and view in code like below, or use
    // the Form designer in Visual Studio to set them.  If you set them in code,
    // place the following in Form.Load
    listView1.View = View.Details;
    
    listView1.Columns.Add("Boat Name", -2, HorizontalAlignment.Left);
    listView1.Columns.Add("Length", -2, HorizontalAlignment.Left);
    listView1.Columns.Add("Sail Size", -2, HorizontalAlignment.Left);
    listView1.Columns.Add("Engines", -2, HorizontalAlignment.Center);
    
    // When you want to add a boat to the ListView, use code like the following:
    ListViewItem item1 = new ListViewItem(txtBoatName.Text,0);
    item1.SubItems.Add(txtLength.Text);
    item1.SubItems.Add(txtSailSize.Text);
    item1.SubItems.Add(txtEngines.Text);
    
    listView1.Items.Add(item1);
