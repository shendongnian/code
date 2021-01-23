    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {
       MenuItem menuItem = (MenuItem)e.Source;
       ContextMenu contextMenu = menuItem.CommandParameter as ContextMenu;
       ListViewItem item = (ListViewItem)contextMenu.PlacementTarget;
       var x = ((myViewModel)(item.Content)).myModel;
       //'x' gives all required data of list view item
    }
