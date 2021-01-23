    List<int> toRemove = new List<int>();
    foreach (ListViewItem item in this.listView.Items)
    {
        if (item.Checked) // check other remove conditions here
            toRemove.Add(item.Index);
    }
    /* sort indices descending, so you'll remove items with higher indices first
       and they will not be shifted when you remove items with lower indices */
    toRemove.Sort((x, y) => y.CompareTo(x));
    /* in this specific case you can simply use toRemove.Reverse(); 
       or iterate thru toRemove in reverse order
       because it is already sorted ascending.
       But you might want to force sort it descending in some other cases.
    */
    this.listView.BeginUpdate();
    foreach (int itemIndex in toRemove)
        this.listView.Items.RemoveAt(itemIndex); // use RemoveAt when possible. It's much faster with large collections
    this.listView.EndUpdate();
