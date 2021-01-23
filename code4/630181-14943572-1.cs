    private void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e) {
        if (((e.Item.ItemType == ListItemType.AlternatingItem) 
                    || (e.Item.ItemType == ListItemType.Item))) {
            LinqDataSource lds = ((LinqDataSource)(e.Item.FindControl("RadComboBox77")));
            ((RadComboBox)(e.Item.FindControl("RadComboBox77"))).DataSourceID = lds.ID;
        }
    }
