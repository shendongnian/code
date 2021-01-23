    _model.Series.Clear();
    foreach (var currency in distinctCurrencies)
    {
        IEnumerable<DataPoint> dataPoints = ...;
        LineSeries lineSeries = new LineSeries()
        {
            Title = String.Format("*{0}", currency),
            ItemsSource = dataPoints
        };
        _model.Series.Add(lineSeries);
    }
