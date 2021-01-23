	protected void CategoryRepeater_ItemDataBound(object sender, 
		RepeaterItemEventArgs e)
	{
		if (e.Item.ItemType == ListItemType.Item || 
			e.Item.ItemType == ListItemType.AlternatingItem)
		{
			DataRowView row = (DataRowView)e.Item.DataItem;
			int? catID = row["catid"] as int;
		}
	}
