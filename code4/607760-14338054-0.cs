    DataTable myDataTable = new DataTable();
    //......
    string[] uniqueItems = myDataTable.AsEnumerable()
                                      .Select(r=> r.Field<string>("MyColumn"))
                                      .Distinct()
                                      .ToArray();
;
