    List<double> series1X = new List<double> {   0,   2,   4,   6,  8 };
    List<double> series1Y = new List<double> { 120, 100, 110, 105, 70 };
    List<double> series2X = new List<double> {   0,   1,   7,   8,  9 };
    
    // in the worst case there are n + m new points
    List<double> newSeries1X = new List<double>(series1X.Count + series2X.Count);
    List<double> newSeries1Y = new List<double>(series1X.Count + series2X.Count);
    
    int i = 0, j = 0;
    for ( ; i < series1X.Count && j < series2X.Count; )
    {
        if (series1X[i] <= series2X[j])
        {
            newSeries1X.Add(series1X[i]);
            newSeries1Y.Add(series1Y[i]);
            if (series1X[i] == series2X[j])
            {
                j++;
            }
            i++; 
        }
        else
        {
            int k = (i == 0) ? i : i - 1;
            // interpolate
            double y0 = series1Y[k];
            double y1 = series1Y[k + 1];
            double x0 = series1X[k];
            double x1 = series1X[k + 1];
            double y = y0 + (y1 - y0) * (series2X[j] - x0) / (x1 - x0);
            newSeries1X.Add(series2X[j]);
            newSeries1Y.Add(y);
            j++;
        }
    }
    for ( ; i < series1X.Count; i++)
    {
        newSeries1X.Add(series1X[i]);
        newSeries1Y.Add(series1Y[i]);
    }
    for ( ; j < series2X.Count; j++)
    {
        // interpolate
        double y0 = series1Y[i - 2];
        double y1 = series1Y[i - 1];
        double x0 = series1X[i - 2];
        double x1 = series1X[i - 1];
        double y = y0 + (y1 - y0) * (series2X[j] - x0) / (x1 - x0);
        newSeries1X.Add(series2X[j]);
        newSeries1Y.Add(y);
    }
