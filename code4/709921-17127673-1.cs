    //add columns appropriately
    DataTable table = new DataTable();
    table.Columns.Add("Name", typeof(string));
    table.Columns.Add("Order", typeof(string));
    table.Columns.Add("Date", typeof(string));
    foreach (var row in patient_list)
        table.Rows.Add(row);
    return table;
