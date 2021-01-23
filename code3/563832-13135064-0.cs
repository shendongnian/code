    public Series CreateSeries(Dictionary<DateTime, double> values)
    {
        var series = new Series();
     
        //Our x Value   
        var x = 0;
        //Loop through our values-Collection ordered by the date
        foreach (var value in values.OrderBy(item => item.Key))
        {
            //Add a point using our dummy value
            series.Points.Add(
                new DataPoint(x, value.Value) 
                {
                    //AxisLabel sets the X-Axis-Label - here: our datestring
                    AxisLabel = item.Key.ToShortDateString() 
                });
            //increment our dummy
            x++;
        }
        return series;
    }
    
    
