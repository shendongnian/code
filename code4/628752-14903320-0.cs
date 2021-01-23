    protected void myListView_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
    		var yourLabel = e.Item.FindControl("Label1") as Label;
    		
    		// ...
        }
    }
