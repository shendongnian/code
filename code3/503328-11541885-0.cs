    private void OnAlarmItemExpanded(object sender, RoutedEventArgs e)
    {
        TreeViewItem treeNode = sender as TreeViewItem;
        string header = treeNode.Header.ToString();
        if (expandedNodes.Contains(header) == false)
        {
            expandedNodes.Add(header);
        }
    }
    private void OnAlarmItemCollapsed(object sender, RoutedEventArgs e)
    {
        TreeViewItem treeNode = sender as TreeViewItem;
        string header = treeNode.Header.ToString();
        if (expandedNodes.Contains(header))
        {
            expandedNodes.Remove(header);
        }
    } 
