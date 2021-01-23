    foreach (RepeaterItem item in rptItems.Items)
    {
        if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
        {
            var lbl= (Label)item.FindControl("lblMyLabel");
    
            lbl.Text = "do something to your label";
        }
    }
