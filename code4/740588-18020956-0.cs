    protected void radGrid_ItemDatabound(object sender, GridItemDataBoundEventArgs e)
    {
    	// the header is binding to the treelist
    	if (e.Item is GridHeaderItem)
    	{
    		var item = e.Item as GridHeaderItem;
    		item.BackColor = Color.Green;
    	}
    }
