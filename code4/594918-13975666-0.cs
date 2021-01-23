    GridRecord selectedRow = e.CurrentSelectedRows[0];
    DataRowView dataItem = (DataRowView)selectedRow.DataItem;
    DataRow dataRow = dataItem.Row;
    object[] valueArray = dataRow.ItemArray;
    int columnIndex = WebDataGrid1.Columns["Status"].Index;
    string statusValue = selectedRow.Items[columnIndex].Value.ToString();
    if (statusValue != "Released") {
        //do stuff
    }
