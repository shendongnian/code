    private bool CheckItemHeader(ItemCollection treeViewItems, string input)
    {
        for (int index = 0; index < treeViewItems.Count; index++)
        {
            TreeViewItem item = (TreeViewItem)treeViewItems[index];
            if (item.Header == input) return true;
            else if (item.Items.Count > 1) return CheckItemHeader(item.Items, input);
        }
        return false;
    }
