    var table = new DataTable("Dates");
    var dateColumn = new DataColumn("Date", typeof (DateTime));
    table.Columns.Add(dateColumn);
    table.BeginLoadData();
    table.LoadDataRow(new object[] {new DateTime(2000, 1, 1)}, true);
    table.LoadDataRow(new object[] {new DateTime(2000, 1, 2)}, true);
    table.LoadDataRow(new object[] {new DateTime(2001, 1, 1)}, true);
    table.LoadDataRow(new object[] {new DateTime(2002, 1, 1)}, true);
    table.EndLoadData();
