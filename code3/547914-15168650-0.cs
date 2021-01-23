    ClearSelection(this.treeView);
    this.treeView.SelectedValuePath = ".";
    this.treeView.ClearValue(TreeView.SelectedValuePathProperty);
    this.treeView.ItemsSource = null;
...
    public static void ClearSelection(TreeView treeView)
    {
        if (treeView != null)
            ClearSelection(treeView.Items, treeView.ItemContainerGenerator);
    }
    private static void ClearSelection(ItemCollection collection, ItemContainerGenerator generator)
    {
        if ((collection != null) && (generator != null))
        {
            for (int i = 0; i < collection.Count; i++)
            {
                TreeViewItem treeViewItem = generator.ContainerFromIndex(i) as TreeViewItem;
                if (treeViewItem != null)
                {
                    ClearSelection(treeViewItem.Items, treeViewItem.ItemContainerGenerator);
                    treeViewItem.IsSelected = false;
                }
            }
        }
    }
