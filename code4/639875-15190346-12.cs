	protected void rptDummy_OnItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
		{
			IGrouping<string, Tuple<string, string>> group = (IGrouping<string, Tuple<string, string>>)e.Item.DataItem;
			RadioButtonList list = (RadioButtonList)e.Item.FindControl("rbl");
			list.DataSource = group;
			list.DataBind();
		}
	}
