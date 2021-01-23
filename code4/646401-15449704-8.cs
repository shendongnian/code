    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        this.DetachAllEventsFromSeries();
    
        chart.Series.Clear();
    
        AddSeries();
    }
    
    private void DetachAllEventsFromSeries()
    {
        var plotAreaProperty = typeof(DataPointSeries).GetProperty("PlotArea", BindingFlags.Instance | BindingFlags.NonPublic);
        var detachMethod = typeof(DataPointSeries).GetMethod("DetachEventHandlersFromDataPoints", BindingFlags.Instance | BindingFlags.NonPublic);
    
        foreach (var series in chart.Series.OfType<DataPointSeries>().ToList())
        {
            var plotArea = (Panel)plotAreaProperty.GetValue(series, null);
            if (plotArea == null)
            {
                continue;
            }
    
            var datapoints = plotArea.Children.OfType<DataPoint>().ToList();
            detachMethod.Invoke(series, new[] { datapoints });
        }
    }
