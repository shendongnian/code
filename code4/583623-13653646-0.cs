    protected void Repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
    	// make sure we are not checking item in ItemHeader or ItemFooter to prevent null value
    	if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
    		string myVar = XPathBinder.Eval(e.Item.DataItem,"title").ToString();
    
    		// utilize and manipulate myVar XML value here
    	}
    }
