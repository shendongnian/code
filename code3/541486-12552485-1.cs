    var result = dtChartData.AsEnumerable()
                .GroupBy(row => new
                    {
                        Value = row.Field<int>("Value"),
                        Description = row.Field<string>("Description")
                    })
                .Select(g =>
                    {
                        var row = g.First();
                        row.SetField("Hours", g.Sum(r => r.Field<double>("Hours")));
                        return row;
                    });
