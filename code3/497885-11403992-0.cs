    lstvUsers.Items.Clear();
    foreach (Hashtable i in online_list)
    {
        ListViewItem item = new ListViewItem();
        item.Text = (string)i["u_name"];
        item.Name = (string)i["id"];
        item.ImageIndex = 0;
        if(!lstvUsers.Items.Contains(item))
            lstvUsers.Items.Add(item);
    }
