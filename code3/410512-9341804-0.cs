    void removeItem_Click(object sender, RoutedEventArgs e)
    {
        // Find name of Button that contained this item
        MenuItem    menuItem      = (MenuItem)sender;
        ContextMenu contextMenu   = (ContextMenu)menuItem.Parent;
        Button      button        = (Button)contextMenu.PlacementTarget;
        string buttonName = button.Name;
    }
