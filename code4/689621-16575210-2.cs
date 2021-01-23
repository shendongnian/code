    dt1.AsEnumerable()
        .Join(dt2.AsEnumerable(),
            d => d.Field<string>("col1D"),
            d => d.Field<string>("col2A"),
            (d1, d2) => new { Dt1 = d1, Dt2 = d2 })
        .Select(a => {
                DataRow newRow = dt3.NewRow();
                newRow.SetField("colA", a.Dt1.Field<int>("col1A"));
                newRow.SetField("colB", a.Dt1.Field<string>("col1B"));
                newRow.SetField("colC", a.Dt1.Field<string>("col1C"));
                newRow.SetField("colD", a.Dt2.Field<string>("col2B"));
                return newRow;
            })
        .CopyToDataTable(dt3, LoadOption.OverwriteChanges);
