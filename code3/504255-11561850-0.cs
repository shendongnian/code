    DataTable table = new DataTable();
    table.Columns.Add("ID", typeof(int));
    table.Columns.Add("ProductName");
    
    table.Rows.Add(1, "Chai");
    table.Rows.Add(2, "Queso Cabrales");
    table.Rows.Add(3, "Tofu");
    
    EnumerableRowCollection<DataRow> Rows = table.AsEnumerable();
    
    foreach (DataRow Row in Rows)
        Row["ID"] = (int)Row["ID"] * 2;
