    var idsNotInB = TableA.AsEnumerable().Select(r => r.Field<int>("id"))
            .Except(TableB.AsEnumerable().Select(r => r.Field<int>("id")));
    DataTable TableC = (from row in TableA.AsEnumerable()
                       join id in idsNotInB 
                       on row.Field<int>("id") equals id
                       select row).CopyToDataTable();
