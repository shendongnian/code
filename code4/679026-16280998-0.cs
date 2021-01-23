    private void LoadLineChartData()
    {
    //Chart is your chart object in Xaml
    //declare your series
    LineSeries ls = new LineSeries();
    
    ls.Title = "Monthly Count";
    ls.IndependentValueBinding = new Binding("Key");
    ls.DependentValueBinding = new Binding("Value");
    ls.ItemsSource = new KeyValuePair<DateTime, int>[]{
        new KeyValuePair<DateTime,int>(DateTime.Now, 100),
        new KeyValuePair<DateTime,int>(DateTime.Now.AddMonths(1), 130),
        new KeyValuePair<DateTime,int>(DateTime.Now.AddMonths(2), 150),
        new KeyValuePair<DateTime,int>(DateTime.Now.AddMonths(3), 125),
        new KeyValuePair<DateTime,int>(DateTime.Now.AddMonths(4),155)};
    
    // then add it to the chart
    Chart.Series.Add(ls);
    
    }
