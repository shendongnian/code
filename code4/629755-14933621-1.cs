    protected void Dlitems_ItemDataBound(Object sender, DataListItemEventArgs e)
    {
       if (e.Item.ItemType == ListItemType.Header)
       {
           Label lblCat = (Label)e.Item.FindControl("lblcat");
           lblCat.Text = "Changed!";
        
        }    
    }
