    private void GridView_ItemClick(object sender, ItemClickEventArgs e)
            {
                // This is how you determine the clicked item in a GridView,
                // and obtain the relevant element of the underlying collection
                // (to which the GridView is bound).
                // 'Tile' is here the 'type' used in the said collection.
                Tile output = e.ClickedItem as Tile;
    
                // ... 
    
            }
