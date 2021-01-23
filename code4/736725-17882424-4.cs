    public void RemoveChildNode(List<TreeViewItem> items, List<TreeViewItem> toDelete)
    {
        if (toDelete.Count == 0)
            return;
        if (items.Count == 0)
            return;
        for (int i = items.Count - 1; i >= 0; i--)
        {
            TreeViewItem item = items[i];
            int indexOf = toDelete.IndexOf(item);
            if (indexOf == -1)
            {
                RemoveChildNode(item.Items, toDelete);
            }
            else
            {
                toDelete.RemoveAt(indexOf);
                items.RemoveAt(i);
            }
        }
    }
