       var appTile = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString() == "/");
       if (appTile != null)
       {
            var standardTile = new StandardTileData
            {
                    Title = "ShareSky",
                    BackgroundImage = new Uri("/Background.png", UriKind.RelativeOrAbsolute),
                    BackTitle = "ShareSky",
                    BackBackgroundImage = new Uri("/flipped.png", UriKind.RelativeOrAbsolute),
                    BackContent = "backcontent load"
            };
            appTile.Update(standardTile);
         }
