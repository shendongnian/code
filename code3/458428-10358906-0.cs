    foreach (DataListItem dli in DataList1.Items)
    {
        if (dli.ItemType == ListItemType.Item || dli.ItemType == ListItemType.AlternatingItem)
        {
            Panel button = (Panel)e.Item.FindControl("btnButton");
            button.CssClass = ("altClass");
        }
    }
