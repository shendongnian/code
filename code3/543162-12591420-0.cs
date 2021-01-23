    ITileSquareText04 squareContent = TileContentFactory.CreateTileSquareText04(); 
    squareContent.TextBodyWrap.Text = "Hello World"; 
    tileContent.SquareContent = squareContent; 
    
    // send the notification
    TileUpdateManager.CreateTileUpdaterForApplication()
        .Update(tileContent.CreateNotification()); 
