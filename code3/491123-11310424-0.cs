    // Override the navigationParameter if a page state is set:
	if (pageState != null && pageState.ContainsKey("SelectedItem"))
	{
		navigationParameter = pageState["SelectedItem"];
	}
	var item = ArticleDataSource.GetItem((int)navigationParameter);
	if (item != null)
	{
		DefaultViewModel["Group"] = item.Group;
		DefaultViewModel["Items"] = item.Group.Items;
		if (itemsViewSource.View != null)
		{
			itemsViewSource.View.MoveCurrentTo(item);
		}
		else
		{
			// A serious error happened here..
		}
	}
	else
	{
		// Oooops, an item disappeared..
	}
