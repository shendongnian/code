    var series =  MeterReadings.GroupBy(x => x.Name)
                               .Select(g => new Series
                                {
                                    Name = g.Key,
                                    Data = new Data(g.Select(x => x.Value).ToArray())
                                })
                               .ToArray();
    var chartData = new ChartData {Series = series};
