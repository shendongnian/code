    HashSet<int> orderIDs = new HashSet<int>(orders.Select(o => o.id));
	Dictionary<string, bool> scopeComputersSelectedState = 
		scopeComputers.ToDictionary(s => s.CName, s => s.Selected);
    foreach (System.Web.UI.WebControls.ListItem item in OrdersChoiceList.Items)
    {
        if (orderIDs.Contains(item.id))
            item.Selected = scopeComputersSelectedState[item.Text];
    }
