    foreach(string s in theDatabase.listDeliveries())
    {
    ListViewItem item = new ListViewItem(s);
    item.BackColor = Color.Blue;
    listbox.Items.Add(item);
    }
