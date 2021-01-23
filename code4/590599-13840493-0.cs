    var distinct = from row in table.AsEnumerable()
                   group row by new
                   {
                       Col1 = row.Field<string>("Column1"),
                       Col2 = row.Field<string>("Column2")
                   } into Group
                   select Group.First()
    DataTable tblDistinct = distinctRows.CopyToDataTable();
