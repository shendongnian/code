    var query = table.Rows.Cast<DataRow>()
        .GroupBy(r => ((DateTime)r[0]).Second)
        .Select(g => new
                     {
                        g.Key, 
                        Sum = g.Sum(r => (int)r[2]),
                        Average = g.Average(r => (int)r[3])
                     });
