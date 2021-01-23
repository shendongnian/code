    private void CreateLiveTile(TileItem item)
    {
        string tileParameter = "Param=" + item.Title.ToString();
         //...
        if (Tile == null)
        {
            try
            {
                var LiveTile = new StandardTileData
                {
                  //...
                };
                ShellTile.Create(new Uri("/MainPage.xaml?" + tileParameter, UriKind.Relative), LiveTile);  //pass the tile parameter as the QueryString
              //blah-blah-blah
    }
