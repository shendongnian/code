    FlipTileData TileData = new FlipTileData()
    {
       Title = "[title]",
       BackTitle = "[back of Tile title]",
       BackContent = "[back of medium Tile size content]",
       WideBackContent = "[back of wide Tile size content]",
       Count = [count],
       SmallBackgroundImage = [small Tile size URI],
       BackgroundImage = [front of medium Tile size URI],
       BackBackgroundImage = [back of medium Tile size URI],
       WideBackgroundImage = [front of wide Tile size URI],
       WideBackBackgroundImage = [back of wide Tile size URI],
    };
    
    ShellTile.Create(new Uri("/LiveTimes.xaml?name=" + busStopName.Text, UriKind.Relative), TileData, true);
