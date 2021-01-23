    // create the wide template
    ITileWide310x150PeekImageAndText01 wideContent = TileContentFactory.CreateTileWide310x150PeekImageAndText01();
    wideContent.TextBodyWrap.Text = "some text";
    wideContent.Image.Src = "ms-appx:///Assets/WideLogo.png";
    
    // create the square template and attach it to the wide template 
    ITileSquare150x150Block squareContent = TileContentFactory.CreateTileSquare150x150Block();
    squareContent.TextBlock.Text = "01";
    squareContent.TextSubBlock.Text = "Tue";
    wideContent.Square150x150Content = squareContent;
    
    var tn = new TileNotification(wideContent.GetXml());
    TileUpdateManager.CreateTileUpdaterForApplication("App").Clear();
    TileUpdateManager.CreateTileUpdaterForApplication("App").Update(tn);
