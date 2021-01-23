    DataTable table = new DataTable();
    table.Columns.Add("Dosage", typeof(int));
    table.Columns.Add("Drug", typeof(string));
    table.Columns.Add("Patient", typeof(string));
    table.Columns.Add("Date", typeof(DateTime));
    // Here we add five DataRows.
    table.Rows.Add(25, "Indocin", "David", DateTime.Now);
    table.Rows.Add(50, "Enebrel", "Sam", DateTime.Now);
    table.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
    table.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
    table.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now);
    var rows = table.AsEnumerable().Where(dr => dr.ItemArray.Contains("David"));
    DataTable copyTable = new DataTable();
    copyTable.Columns.Add("Dosage", typeof(int));
    copyTable.Columns.Add("Drug", typeof(string));
    copyTable.Columns.Add("Patient", typeof(string));
    copyTable.Columns.Add("Date", typeof(DateTime));
    foreach (var row in rows)
    {
        copyTable.Rows.Add(row.ItemArray);
    }
