    var query =
        from dt1 in DataTable1.AsEnumerable()
        join dt2 in DataTable2.AsEnumerable()
            on dt1.Field<string>("col1D") equals dt2.Field<string>("col2A")
        select new
        {
            col1A = dt1.Field<int>("col1A"),
            col1B = dt1.Field<string>("col1B"),
            col1C = dt1.Field<string>("col1C"),
            col2B = dt2.Field<string>("col2B")
        };
    foreach (var x in query)
    {
        DataRow newRow = DataTable3.Rows.Add();
        newRow.SetField("col1A", x.col1A);
        newRow.SetField("col1B", x.col1B);
        newRow.SetField("col1C", x.col1C);
        newRow.SetField("col2B", x.col2B);
    }
