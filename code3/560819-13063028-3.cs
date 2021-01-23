    var result = table.AsEnumerable()
                .GroupBy(r => new
                    {
                         Version = r.Field<String>("Version"),
                         Col1 =  r.Field<String>("Col1"),
                         Col2 =  r.Field<String>("Col2")
                    })
                .Select(g =>
                    {
                        var row = g.First();
                        row.SetField("Value", g.Sum(r => r.Field<int>("Value")));
                        return row;
                    }).CopyToDataTable();
