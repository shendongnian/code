    listview.BeginUpdate();
    foreach (User u in userList)
    {
        ListViewItem item = new ListViewItem() { Text = u.Name, Tag = u};
        listview.Items.Add(item);
    }
    listview.EndUpdate();
