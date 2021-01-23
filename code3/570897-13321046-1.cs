    var series = (from d in MeterReadings
                  group d by new { name = d.Name } into g
                  from s in g select new Series
                      {
                          Name = g.Key.name,
                          Data = new Data(new object[] { g.Select(x => x.Value) })
                      })
                  .ToArray();
    var chartData = new ChartData {Series = series};
