	protected void rptDummy_OnItemDataBound(object sender, RepeaterItemEventArgs e)
	{
		if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
		{
			IGrouping<string, Tuple<string, string>> group = (IGrouping<string, Tuple<string, string>>)e.Item.DataItem;
			RadioButtonList list = new RadioButtonList();
			list.ID = "rbl";
			foreach (var item in group)
			{
				list.Items.Add(new ListItem(item.Item2, item.Item2));
			}
			e.Item.Controls.Add(list);
		}
	}
