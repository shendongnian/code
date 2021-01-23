       27  // Select the application tile
       28             ShellTile myTile = ShellTile.ActiveTiles.First();
       29             if (myTile != null)
       30             {
       31                 // Create a new data to update my tile with
       32                 FlipTileData newTileData = new FlipTileData
       33                 {
       34                     Title = “New Title”,
       35                     BackgroundImage = new Uri(@”Assets\Tiles\ChangedTileMedium.png”, UriKind.Relative),
       36                     BackTitle = “New Background Image”,
       37                     BackBackgroundImage = new Uri(textBoxBackBackgroundImage.Text, UriKind.Relative),
       38                     BackContent = “New Back Content”
       39                 };
       40                 // Update the application Tile
       41                 myTile.Update(newTileData);
       42             }
