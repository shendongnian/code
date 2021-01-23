    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.EditItem)
        {
            DropDownList dropDownList1 = (DropDownList)e.Item.FindControl("Dropdownlist1");
            DataRowView dataItem1 = (DataRowView)e.Item.DataItem;
            dropDownList1.SelectedValue = (string)dataItem1.Row["kundertype"];
    
            DropDownList dropDownList2 = (DropDownList)e.Item.FindControl("Dropdownlist2");
            DataRowView dataItem2 = (DataRowView)e.Item.DataItem;
            dropDownList2.SelectedValue = (string)dataItem2.Row["anrede"];
        }
    }
