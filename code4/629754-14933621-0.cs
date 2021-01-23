     protected void Item_Bound(Object sender, DataListItemEventArgs e)
      {
    
         if (e.Item.ItemType == ListItemType.Header)
         {
            // Retrieve the Label control in the current DataListItem.
            Label lblCat = (Label)e.Item.FindControl("lblcat");
            lblCat.Text = "Changed!";
    
         }
    
      }
