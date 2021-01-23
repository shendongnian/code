    IconicTileData newTileData = new IconicTileData
    {
        Title = SharedResources.AppName,
        Count = BatteryHelper.BateryLevel,
        SmallIconImage = new Uri(@"/Assets/IconicSmall.png", UriKind.Relative),
        IconImage = new Uri(@"/Assets/IconicMedium.png", UriKind.Relative),
    };
