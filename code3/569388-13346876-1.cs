    protected void rptDestinationCount_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            using (MarketingWebContentEntities context = new MarketingWebContentEntities())
            {
                Label lblCount = (Label)e.Item.FindControl("lblCount");
                HiddenField hidURLGroupRowID = (HiddenField)e.Item.FindControl("hidURLGroupRowID");
                int groupRowID = Convert.ToInt32(hidURLGroupRowID.Value);
                var destination = (from dest in context.URLDestination
                                   where dest.URLGroup.URLGroupRowID == groupRowID
                                   select dest).ToList();
                lblCount.Text = destination.Count.ToString();
            }
        }
    }
