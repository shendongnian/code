    private static TreeViewItem[] getTreeViewItems(TreeView treeView)
    {
        List<TreeViewItem> returnItems = new List<TreeViewItem>();
        for (int x = 0; x < treeView.Items.Count; x++)
        {
            returnItems.AddRange(getTreeViewItems((TreeViewItem)treeView.Items[x]));
        }
        return returnItems.ToArray();
    }
    private static TreeViewItem[] getTreeViewItems(TreeViewItem currentTreeViewItem)
    {
        List<TreeViewItem> returnItems = new List<TreeViewItem>();
        returnItems.Add(currentTreeViewItem);
        for (int x = 0; x < currentTreeViewItem.Items.Count; x++)
        {
            returnItems.AddRange(getTreeViewItems((TreeViewItem)currentTreeViewItem.Items[x]));
        }
        return returnItems.ToArray();
    }
