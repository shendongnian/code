    LineSeries lineSeries = new LineSeries();
    lineSeries.VerticalAxis = new LinearAxis() 
    { //set additional properties here 
        LabelStyle = Resources["AdjustedLabelVerticalAxis"] as Style
    };
    lineSeries.ItemsSource = collection.Values;
    lineSeries.CategoryBinding = new PropertyNameDataPointBinding() { PropertyName = "Date" };
    lineSeries.ValueBinding = new PropertyNameDataPointBinding() { PropertyName = "Value" };
    RadCartesianChart chart = new RadCartesianChart();
    chart.HorizontalAxis = new DateTimeContinuousAxis() { LabelFormat = "HH:mm:ss" };
    chart.Series.Add(lineSeries);
