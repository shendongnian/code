    DataTable table = new DataTable();
    table.Columns.Add("ID", typeof(int));
    table.Columns.Add("BugDescription", typeof(string));
    table.Columns.Add("UnitPrice", typeof(double));
    table.Rows.Add(1, "Bug 1", 10.00);
    table.Rows.Add(2, "Bug 2", 20.00);
    string description = table.Select("ID = 1").First().Field<string>("BugDescription");
