    MyObject myObj = new MyObject();
    
    ListViewItem item = new ListViewItem();
    item.Text = myObj.ToString(); // Or whatever display text you need
    item.Tag = myObj;
    // Setup other things like SubItems, Font, ...
    listView.Items.Add(item);
