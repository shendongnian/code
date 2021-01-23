     // Check to see if this restaurant exists as a secondary tile and then unpin it
     string restaurantKey = this.m_ViewModel.Restaurant.Key;
     Button button = sender as Button;
     if (button != null)
     {
         if (Windows.UI.StartScreen.SecondaryTile.Exists(restaurantKey))
         {
             SecondaryTile secondaryTile = new SecondaryTile(restaurantKey);
             bool isUnpinned = await secondaryTile.RequestDeleteForSelectionAsync(GetElementRect((FrameworkElement)sender), Windows.UI.Popups.Placement.Above);
             if (!isUnpinned)
             {
                 // Do error handling here
             }
         }
         else
         {
             // If we ever get to this point, something went wrong or the user manually 
             // removed the tile from their Start screen.  
             Debug.WriteLine(restaurantKey + " is not currently pinned.");
         }
     }
