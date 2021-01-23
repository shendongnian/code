    protected void rptItems_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.AlternatingItem && e.Item.ItemType != ListItemType.Item)
        {
            return;
        }
    
        var currentItem = e.Item as YourDataItemTypeHere;
        var td9 = e.Item.FindControl("Td9") as HtmlTableCell;
        td9.Attributes["title"] = currentItem.Item1Status;
        td9.Style["background-color"] = currentItem.Item2StatusColour;
    
        ...
    }
