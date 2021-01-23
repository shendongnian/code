    protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || 
                               e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HtmlGenericControl ctl = (HtmlGenericControl)e.Item.FindControl("lg");
            ctl.InnerText //This is what will give you the result.
        }
    }
