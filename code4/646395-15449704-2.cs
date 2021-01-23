    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        foreach (var series in chart.Series.OfType<Series>())
        {
            series.DataContext = null;
        }
    
        chart.Series.Clear();
        AddSeries();
    }
