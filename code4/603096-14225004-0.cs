    int count = 0;
    LineSeries lineSeries = new LineSeries();
    lineSeries.CategoryBinding = new PropertyNameDataPointBinding() { PropertyName = "TimeStamp" };
    lineSeries.ValueBinding = new PropertyNameDataPointBinding() { PropertyName = "Value" };  
  
    lineSeries.VerticalAxis = new LinearAxis()
    {
       Title = "Title Here"
    };
    lineSeries.ItemsSource = yourCollection.Values;
    
    //First Y-axis to be placed on the left of X-axis,
    //additional Y-axes to be placed on right
    if (count > 0 )
    {
         lineSeries.VerticalAxis.HorizontalLocation = Telerik.Charting.AxisHorizontalLocation.Right;
    }
    count++;
    chartName.Series.Add(lineSeries);
    
