    protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            string file = e.Item.DataItem as string;
            HyperLink hyp = e.Item.FindControl("hyp") as HyperLink;
            hyp.Text = file;
            hyp.NavigateUrl = string.Format("~/Handlers/FileHandler.ashx?file={0}", file);
        }
    }
