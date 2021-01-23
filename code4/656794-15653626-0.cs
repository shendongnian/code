    // Create the `DataTable` structure according to your data source
    DataTable table = new DataTable();
    table.Columns.Add("FileNumber", typeof(int));
    table.Columns.Add("ShiftDate", typeof(DateTime));
    table.Columns.Add("TimeCreated", typeof(DateTime));
    table.Columns.Add("Remarks", typeof(string));
    // Iterate throw data source object and fill the table
    foreach (var item in CollectionUserData)
    {
        table.Rows.Add(item.FileNumber, item.ShiftDate, item.TimeCreated, item.Remarks);
    }
