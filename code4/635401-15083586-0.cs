    object[][] points = readings.Select(
          pair => new object[] { pair.Key, pair.Value }).ToArray();
    Series series = new Series
    {
        Type = ChartTypes.Pie,
        Name = "",
        Data = new Data(points))
    };
