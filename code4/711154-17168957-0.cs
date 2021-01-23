    protected void OnCheckboxListItemBound(Object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HtmlTableRow itemRow = (HtmlTableRow) e.Item.FindControl("itemRow");
            itemRow.Visible = e.Item.ItemIndex % 2 == 0;
        }
    }
