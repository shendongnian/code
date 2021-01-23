    var idsNotInB = TablA.AsEnumerable().Select(r => r.Field<int>("id"))
            .Except(TablB.AsEnumerable().Select(r => r.Field<int>("id")));
    DataTable TableC = (from row in TableA.AsEnumerable()
                       join id in idsNotInB 
                       on id equals row.Field<int>("id") 
                       select row).CopyToDataTable();
