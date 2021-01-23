    LinearAxis axis = new LinearAxis();
    LineSeries ls = new LineSeries();
    RadCartesianChart blankChart = new RadCartesianChart();
    ls.ItemsSource = collection.Values;  //Set up for binding
    ls.CategoryBinding = new PropertyNameDataPointBinding() { PropertyName = "Date" };
    ls.ValueBinding = new PropertyNameDataPointBinding() { PropertyName = "Value" };
    ls.Visibility = System.Windows.Visibility.Hidden; //hide the line from being plotted
    axis.LabelStyle = Resources["TextBlockStyle2"] as Style;
    axis.Opacity = 0; //make it invisible
    axis.MinHeight = 0; //make it able to resize to 0 if ever needed
    blankChart.MinHeight = 0; 
    blankChart.HorizontalAxis = graph;
    blankChart.VerticalAxis = axis;
            
    blankChart.Series.Add(ls);
    Grid.SetRow(blankChart, collection.Count);
    layout.Children.Add(blankChart);
