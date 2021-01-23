    public static Series GetIrregularTimeChartData()
    {
        List<Series> Series = new List<Series>();
        var chartSeries = db.Graphs.GroupBy(x => new { x.Name })
                          .Select(g => new
                            {
                                Name = g.Key.Name ,
                                Data = g.Select(x => x.Value).ToArray(),
                                Date = g.Select(x => x.ReadDate).ToArray()
                            }).ToArray();
        foreach (var item in chartSeries)
        {
            int lenght = item.Data.Count();
            object[,] data = new object[lenght, 2];
            for (int i = 0; i < lenght; i++)
            {
                data[i, 0] = item.Date[i];
                data[i, 1] = item.Data[i];
            }
            Series localSeries = new Series { Name = item.Name, Data = new Data(data) };
            Series.Add(localSeries);
        }
        return Series;
    }
