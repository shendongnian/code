    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
    
        if (e.Item.ItemType == ListItemType.EditItem)
        {
                DataRowView dataItem1 = (DataRowView)e.Item.DataItem;
                var result = (string)dataItem1.Row["YourColumnName"];
                ......
        }    }
