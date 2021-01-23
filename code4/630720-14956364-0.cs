    DataTable table = new DataTable();
    table.Columns.Add("Col1");
    table.Columns.Add("Col2");
    table.Columns.Add("Col3");
    List<string> longList = Enumerable.Range(1, 99).Select(i => "row " + i).ToList();
