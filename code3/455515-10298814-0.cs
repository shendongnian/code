	SPList oList = oWebsiteRoot.Lists["WplData"];
	SPListItemCollection items = null;
	SPQuery query = new SPQuery();
	query.Query = "<Where><IsNotNull><FieldRef Name='Topic' /></IsNotNull>" +
		"</Where><OrderBy><FieldRef Name='Topic' Ascending='True' /></OrderBy>";
	items = oList.GetItems(query);
	foreach (SPListItem item in items)
	{
		SPFieldLookupValueCollection values = 
			new SPFieldLookupValueCollection(item["Topic"].ToString());
		foreach (SPFieldLookupValue value in values)
		{
			ListItem listItem = new ListItem();
			listItem.Value = value.LookupId.ToString();
			listItem.Text = value.LookupValue;
			TopicDropDownList.Items.Add(listItem);
		}
	}
