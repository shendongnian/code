    public static Series GetTimeSeriesData(IQueryable<YourModel> model, ChartTypes ChartType)
        {
            List<Series> Series = new List<Series>();
            var chartSeries = model.GroupBy(x => x.Name)
                            .Select(g => new
                            {
                                Name = g.Key,
                                Data = g.Select(x => x.Value).ToArray()
                            }).ToArray();
            foreach (var item in chartSeries)
            {
                object[] data = item.Data.Cast<object>().ToArray();
                Series localSeries = new Series { Name = item.Name, Data = new Data(data), Type = ChartType };
                Series.Add(localSeries);
            }
            return Series;
        }
