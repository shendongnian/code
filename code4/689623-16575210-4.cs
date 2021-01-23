    dt1.AsEnumerable()
        .GroupJoin(dt2.AsEnumerable(),
            d1 => d1.Field<int>("col1D"),
            d2 => d2.Field<int>("col2A"),
            (l, r) => new { Left = l, Right = r })
        .Select(anon => {
                if(anon.Right.Any())
                {
                    return anon.Right.Select(r =>
                    {
                        var newRow = dt3.NewRow();
                        newRow.SetField("colA", anon.Left.Field<int>("col1A"));
                        newRow.SetField("colB", anon.Left.Field<string>("col1B"));
                        newRow.SetField("colC", anon.Left.Field<string>("col1C"));
                        newRow.SetField("colD", r.Field<string>("col2B"));
                        return newRow;
                    });
                }
                else
                {
                    var newRow = dt3.NewRow();
                    newRow.SetField("colA", anon.Left.Field<int>("col1A"));
                    newRow.SetField("colB", anon.Left.Field<string>("col1B"));
                    newRow.SetField("colC", anon.Left.Field<string>("col1C"));
                    return new DataRow[] { newRow };
                }
            })
        .Aggregate((accum, next) => accum.Union(next))
        .CopyToDataTable(dt3, LoadOption.OverwriteChanges);
