    protected void Repater1_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        // This event is raised for the header, the footer, separators, and items.
        if (e.Item.ItemType == ListItemType.Footer)
        {
            HyperLink hl = (HyperLink)e.Item.FindControl("HyperLink1");
        }
    }   
