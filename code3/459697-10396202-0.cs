    var dataTable = new DataTable();
    dataTable.Columns.Add("Id", typeof(Int32));
    dataTable.Columns.Add("ParentId", typeof(Int32));
    dataTable.Columns.Add("Name", typeof(String));
    dataTable.Rows.Add(new Object[] { 1, 0, "A" });
    dataTable.Rows.Add(new Object[] { 2, 1, "B" });
    dataTable.Rows.Add(new Object[] { 3, 1, "C" });
    dataTable.Rows.Add(new Object[] { 4, 0, "D" });
    dataTable.Rows.Add(new Object[] { 5, 4, "E" });
