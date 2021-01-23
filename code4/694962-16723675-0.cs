    var viewSeries = new LineSeries
    {
        DataPointStyle = new Style
        {
            TargetType = typeof(DataPoint),
            Setters = { new Setter(TemplateProperty, null) }
        }
    };
    viewSeries.DataPointStyle.Setters.Add(
        new Setter(BackgroundProperty, new SolidColorBrush(Colors.Red)));
