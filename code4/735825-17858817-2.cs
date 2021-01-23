    bool selectedState = scopeComputer.SelectedBox;
    HashSet<int> orderIDs = new HashSet<int>(orders.Select(o => o.id));
    foreach (System.Web.UI.WebControls.ListItem item in OrdersChoiceList.Items)
    {
        if (orderIDs.Contains(item.id))
            item.Selected = selectedState;
    }
