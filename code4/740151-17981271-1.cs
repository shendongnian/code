    private void DoStuff_Click(object sender, RoutedEventArgs e)
    {
        var menuItem = sender as MenuItem;
        if (menuItem == null)
            return;
        var contextMenu = menuItem.Parent as ContextMenu;
        if (contextMenu == null)
            return;
        var listViewItem = contextMenu.PlacementTarget as ListViewItem;
        if (listViewItem == null)
            return;
        var listView = GetListView(listViewItem);
        if (listView == null)
            return;
            
        // do stuff here
    }
    private ListView GetListView(ListViewItem item)
    {
        for (DependencyObject i = item; i != null; i = VisualTreeHelper.GetParent(i))
        {
            var listView = i as ListView;
            if (listView != null)
                return listView;
        }
        return null;
    }
