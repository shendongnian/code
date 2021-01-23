    var groups = from r in dTable.AsEnumerable()
                 group r by new
                 {
                     Col1 = r.Field<String>("Column1"),
                     Col2 = r.Field<String>("Column2"),
                 };
    // if you only want the first row of each group:
    DataTable distinctTable = groups.Select(g => g.First()).CopyToDataTable();
