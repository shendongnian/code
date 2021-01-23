    protected void rptExcursionOuter_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            if (e.Item.DataItem != null)
            {
                var itemsByMonth = (KeyValuePair<int, IEnumerable<Excursion>>)e.Item.DataItem;
                Literal LitExcursionMonth = (Literal)e.Item.FindControl("LitExcursionMonth");
                LitExcursionMonth.Text = itemsByMonth.First().StartDate.ToString("MMMM");
            }
        }
    }
