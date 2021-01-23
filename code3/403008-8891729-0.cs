      void Item_Bound(Object sender, DataListItemEventArgs e)
      {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
           // Retrieve the Button control in the current DataListItem.
           Button btn = (Button)e.Item.FindControl("ItemBtn");
           //Then set the buttons properties over here
         }
       }
