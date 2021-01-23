    treeView.SelectedItemChanged += delegate
    {
        TreeViewItem item = (TreeViewItem)treeView.SelectedItem;
        SparkleLogger.LogInfo("bla", "object:"+item);
        System.Windows.Controls.TreeViewItem subItem = new System.Windows.Controls.TreeViewItem();
        subItem.Header = "hello";
        item.Items.Add(subItem);
    };
