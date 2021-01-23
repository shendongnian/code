    var itemsToAdd = new List<ListViewItem>();
    foreach (KeyValuePair<string, string> listItem in dct)
    {
        ListViewItem item = new ListViewItem(listItem.Key);
        item.SubItems.Add(listItem.Value);
        itemsToAdd.Add(item);
    }
    Invoke(new MethodInvoker(() =>
    {
        listview.Items.AddRange(itemsToAdd);
    }));
