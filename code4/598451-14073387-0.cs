    protected void ListViewTest_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
    	// if it is data item
    	if (e.Item.ItemType == ListViewItemType.DataItem)
    	{
    		// call your function
    		if (isItTrue("test"))
    		{
    			// show the button
    			e.Item.FindControl("btnTest").Visible = true;
    		}
    		else 
    		{
    			// show the label
    			e.Item.FindControl("lblTest").Visible = true;
    		}
    	}
    }
