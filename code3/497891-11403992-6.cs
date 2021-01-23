    var addItems =  online_list
        .Cast<Hashtable>()
        .Where(ht => !lstvUsers.Items.ContainsKey((string)ht["id"]));
    var removeItems = lstvUsers.Items
        .Cast<ListViewItem>()
        .Where(lvi => !online_list.Cast<Hashtable>().Any(ht => (string)ht["id"] ==lvi.Name));
    foreach (var removeItem in removeItems)
    {
        lstvUsers.Items.Remove(removeItem);
    }
    foreach (var addHashTable in addItems)
    {
        ListViewItem item = new ListViewItem();
        item.Text = (string)addHashTable["u_name"];
        item.Name = (string)addHashTable["id"];
        lstvUsers.Items.Add(item);
    }
