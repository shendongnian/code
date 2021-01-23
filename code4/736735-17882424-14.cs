    public void RemoveAll(ItemCollection items, Predicate<TreeViewItem> isValid)
    {
        for (int i = items.Count - 1; i >= 0; i--)
        {
            TreeViewItem vItem = (TreeViewItem)items[i];
            if (isValid(vItem))
            {
                items.RemoveAt(i);
            }else{
                RemoveAll(vItem.Items, isValid);
            }
        }
    }
