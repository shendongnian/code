    Protected void Item_Bound(Object sender, DataListItemEventArgs e)
          {
             if (e.Item.ItemType == ListItemType.Item || 
                 e.Item.ItemType == ListItemType.AlternatingItem)
             {
    
                // Retrieve the ValueHiddenField control in the current DataListItem.
                HiddenField imgPath = (HiddenField)e.Item.FindControl("ValueHiddenField");
                string path = imgPath.Value;
             }
          }
