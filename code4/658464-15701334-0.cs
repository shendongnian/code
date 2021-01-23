    void Item_Bound(Object sender, DataListItemEventArgs e)
    {
    
             if (e.Item.ItemType == ListItemType.Item || 
                 e.Item.ItemType == ListItemType.AlternatingItem)
             {
    
               var lnkbtn = (LinkButton)e.Item.FindControl("lnk_Add");
               lnkbtn.Enabled = false;
    
             }
    
    }
