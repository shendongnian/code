    private void hubTile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
        FrameworkElement element = (FrameworkElement)sender;
        TileItem item = (TileItem)element.DataContext;
        int index = tileItems.IndexOf(item);
        // Use the index
    }
