    protected void repeaterCategories_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
    	if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    	{
    		CheckBox chk = e.Item.FindControl("chbCategoria") as CheckBox ;
    		chk.Attributes.Add("PageID", DataBinder.Eval(e.Item.DataItem, "DB_FIELD").ToString());
    	}
    }
