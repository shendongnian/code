    dt1.AsEnumerable()
        .Join(dt2.AsEnumerable(),
            d => d.Field<string>("col1D"),
            d => d.Field<string>("col2A"),
            (d1, d2) => new { Dt1 = d1, Dt2 = d2 })
        .Select(a => {
                DataRow newRow = dt3.NewRow();
                newRow.SetField("col1A", a.Dt1.col1A);
                newRow.SetField("col1B", a.Dt1.col1B);
                newRow.SetField("col1C", a.Dt1.col1C);
                newRow.SetField("col2B", a.Dt2.col2B);
                return newRow;
            })
        .CopyToDataTable(dt3, LoadOption.OverwriteChanges);
