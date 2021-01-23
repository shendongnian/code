    private void CreateLiveTile(TileItem item)
        {
         
        var title =  item.Title.ToString();
         //...
        if (Tile == null)
        {
            try
            {
                var LiveTile = new StandardTileData
                {
                  //...
                };
                 string page;
            switch (title)
            {
                case "status":
                    page = "/Views/ShareStatusPage.xaml";
                    break;
                case "link":
                    page = "/Views/ShareLinkPage.xaml");
                    break;
            }                
            if(string.IsNullOrEmpty(page))
             { 
                 //handle this situation. for example: page = "/MainPage.xaml";
             }
                ShellTile.Create(new Uri(page, UriKind.Relative), LiveTile); 
              //blah-blah-blah
    }
