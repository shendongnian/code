    List<int> toRemove = new List<int>(this.listView.CheckedItems.Count);
    foreach (ListViewItem item in this.listView.Items)
    {
        if (item.Checked) // check other remove conditions here
            toRemove.Add(item.Index);
    }
    toRemove.Sort((x, y) => y.CompareTo(x));
    this.listView.BeginUpdate();
    foreach (int itemIndex in toRemove)
        this.listView.Items.RemoveAt(itemIndex);
    this.listView.EndUpdate();
