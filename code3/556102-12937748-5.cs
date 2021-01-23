    var table = new DataTable();
    table.Columns.Add("column1", typeof(string));
    table.Columns.Add("column2", typeof(string));
    table.Columns.Add("column3", typeof(string));
    table.Columns.Add("column4", typeof(string));
    table.Columns.Add("column5", typeof(string));
    table.Columns.Add("column6", typeof(string));
    table.Columns.Add("column7", typeof(string));
    table.Columns.Add("column8", typeof(string));
    table.Columns.Add("column9", typeof(string));
    table.Columns.Add("column10", typeof(string));
    for (int i = 0; i < 10; i++)
    {
        table.Rows.Add("colum1", "column2", "colum3", "column4", "column5", "column6", "column7", "column8", "column9", "column10");
    }
    ReorderTable(ref table, "column4", "column2", "column1", "column7", "column6", "column9", "column10", "column5", "column8", "column3");
