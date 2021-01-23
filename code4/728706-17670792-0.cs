    var aIDs = TableA.AsEnumerable().Select(r => r.Field<int>("RowID"));
    var bIDs = TableB.AsEnumerable().Select(r => r.Field<int>("RowID"));
    var diff = aIDs.Except(bIDs);
    DataTable tblDiff = (from r in TableA.AsEnumerable()
                        join dId in diff on r.Field<int>("RowID") equals dId
                        select r).CopyToDataTable();
