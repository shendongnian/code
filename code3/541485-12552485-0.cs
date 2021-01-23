    dtChartData.AsEnumerable()
            .GroupBy(row => new { row.Field<int>("Value"), 
                                  row.Field<string>("Description") })
            .Select(g => {
                var row = g.First();
                row.SetField("Hours", g.Sum(r => r.Field<int>("Hours")));
                
                return row;
           });
