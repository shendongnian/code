    protected void DataList1_ItemCreated(object sender, DataListItemEventArgs e)
    {                  
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Response.Write(e.Item.DataItem.ToString());      
        }
    }
