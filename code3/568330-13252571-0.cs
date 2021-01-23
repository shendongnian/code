    protected void ItemDataBound(object sender, DataListItemEventArgs e)
    {
    	if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    	{
        //Set your session here
        Label lblURL = (Label)e.Item.FindControl("lblURL");
        Session["Session_TaskCode"] = lblURL.Text
    	}
    }
