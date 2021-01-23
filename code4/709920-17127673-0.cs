    DataTable table = new DataTable();
    table.Columns.Add("Name", typeof(string));
    table.Columns.Add("Order", typeof(string));
    table.Columns.Add("Date", typeof(string));
    table.Rows.Add(patient_list.ToArray()); //requires linq. Or loop to create object[]
    return table;
