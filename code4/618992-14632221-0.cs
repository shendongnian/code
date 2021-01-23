    var dict2 = new Dictionary<string, ListViewItem>();
    
    foreach (ListViewItem item in list2.Items)
    {
        dict2.Add(item.SubItems["ProductId"].Text, item);
    }
    
    foreach (ListViewItem item in list1.Items)
    {
        var productId = item.SubItems["ProductId"].Text;
    
        ListViewItem item2;
        if (dict2.TryGetValue(productId, out item2))
        {
            // TODO:
            item2.ForeColor = Color.Green;
        }
    }
