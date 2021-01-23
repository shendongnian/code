    // Convert items to an IEnumerable for LINQ usage
    ListViewItem[] items = new ListViewItem[4];
    listView.Items.CopyTo(items, 0);
    
    // Use LINQ to get values
    IEnumerable<string> secondColumnValues = items.Select(_ => _.SubItems[1].Text);
