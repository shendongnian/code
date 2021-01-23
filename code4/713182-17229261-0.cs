    ShellTile tileToFind = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains("Page2.xaml"));
    if (tileToFind == null) // have not pinned this page yet!
    {
        // Create the tile if we didn't find it already exists.
        var tileData = new StandardTileData
        {
            Title = "Navigate To Page2",
        };
        // Create the tile and pin it to Start. This will cause a navigation to Start and a deactivation of our application.
        ShellTile.Create(new Uri("/Page2.xaml", UriKind.Relative), tileData);
    }
