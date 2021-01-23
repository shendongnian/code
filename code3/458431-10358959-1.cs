    protected void dlDataList_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
             // use the item's DataItem property or the DataList's DataSource property directly
             DataTable tbl = ((DataRowView)e.Item.DataItem).Row.Table;
             if (e.Item.ItemIndex == tbl.Rows.Count - 1)
             {
                 // ....
             }
        }
    }
