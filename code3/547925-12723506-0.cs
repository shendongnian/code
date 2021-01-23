    var foo = newItems.AsEnumerable()
        .GroupBy(item => item.Field<string>(newItems.Columns["BarcodeNumber"]));
    DataTable newTable = new DataTable();
    newTable.Columns.Add("Qty");
    newTable.Columns.Add("BarcodeNumber");
    newTable.Columns.Add("DisplayName");
    newTable.Columns.Add("UnitPrice");
    newTable.Columns.Add("TotalPrice");
    foreach (var item in foo)
    {
        newTable.Rows.Add(
        item.Count(),
        item.Key,
        item.First().Field<string>(newItems.Columns["DisplayName"]),
        item.Sum(row => decimal.Parse(row.Field<string>(newItems.Columns["UnitPrice"]))),
        item.Sum(row => decimal.Parse(row.Field<string>(newItems.Columns["TotalPrice"]))));
    }
