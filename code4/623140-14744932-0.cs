    protected void ContactsListView_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        Label EmailAddressLabel;
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            LinkButton linkButton = e.item.FindControl("LinkButton1") as LinkButton;
            if (linkButton != null)
                linkButton.Visible = false;
        }
    }
