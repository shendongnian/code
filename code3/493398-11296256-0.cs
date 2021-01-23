    if (e.Item.ItemType == ListItemType.Item || 
        e.Item.ItemType == ListItemType.AlternatingItem)
    {
        Label label = (Label)e.Item.FindControl("Label1");
        label.Visible = false;
    }
