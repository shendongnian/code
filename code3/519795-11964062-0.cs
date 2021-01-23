    void MenuItem_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
        var menuItem = (MenuItem)sender;
        var tileItem = menuItem.DataContext as TileItem;
        CreateLiveTile(tileIte);
    }
    enter code here
    private void CreateLiveTile(TileItem item)
    {
        // use the TileItem, not HubTile.
    }
