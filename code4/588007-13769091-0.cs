    protected void repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
    	// if it is an item (not header or footer)
    	if (e.Item.ItemType == ListItemType.Item)
    	{
    		// get your radioButtonList
    		RadioButtonList optionsList = (RadioButtonList)e.Item.FindControl("rblOptionsList");
    
    		// loop in options of the RadioButtonList
    		foreach (ListItem option in optionsList.Items)
            {
    			// add a custom attribute
                option.Attributes["data-flag"] = "true";
            }
    	}
    }
