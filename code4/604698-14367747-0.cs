    var values = res.Values.ToList();
    TimeSpan graphSpan = values.Last().Key - values.First().Key;
    
    if (graphSpan == TimeSpan.Zero)
    {
        lineSeries.IndependentAxis = new DateTimeAxis
        {
            Orientation = AxisOrientation.X,
            Location = AxisLocation.Bottom
        };
    }
    else
    {
        lineSeries.IndependentAxis = new DateTimeAxis
        {
            Minimum = values.First().Key,
            Maximum = values.Last().Key,
            Orientation = AxisOrientation.X,
            Location = AxisLocation.Bottom
        };
    
        if (graphSpan > monthSpan)
        {
            ((DateTimeAxis)lineSeries.IndependentAxis).IntervalType = DateTimeIntervalType.Days;
            ((DateTimeAxis)lineSeries.IndependentAxis).Interval = 5;
        }
        else if (graphSpan > daySpan && graphSpan < monthSpan)
        {
            ((DateTimeAxis)lineSeries.IndependentAxis).IntervalType = DateTimeIntervalType.Days;
            ((DateTimeAxis)lineSeries.IndependentAxis).Interval = 1;
        }
        else if (graphSpan > hourSpan && graphSpan < daySpan)
        {
            ((DateTimeAxis)lineSeries.IndependentAxis).IntervalType = DateTimeIntervalType.Hours;
            ((DateTimeAxis)lineSeries.IndependentAxis).Interval = 1;
        }
        else if (graphSpan < hourSpan)
        {
            ((DateTimeAxis)lineSeries.IndependentAxis).IntervalType = DateTimeIntervalType.Minutes;
            ((DateTimeAxis)lineSeries.IndependentAxis).Interval = 15;
        }
        else
        {
            //sometimes all comparisons fail, just back up to a safe interval of 1 day.
            ((DateTimeAxis)lineSeries.IndependentAxis).IntervalType = DateTimeIntervalType.Days;
            ((DateTimeAxis)lineSeries.IndependentAxis).Interval = 1;
        }
    }
