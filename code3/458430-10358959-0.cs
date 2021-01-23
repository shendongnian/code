    protected void dlDataList_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
             // use the item's DataItem property 
             DataTable tbl = ((DataRowView)e.Item.DataItem).Row.Table;
             // or the DataList's DataSource property directly
             if (e.Item.ItemIndex == tbl.Rows.Count - 1)
             {
                 // ....
             }
        }
    }
