    bool hasS1 = true, hasS2 = true, preinterp = true;
    double x0 = 0, y0 = 0, x1 = 0, y1 = 0, x = 0, y = 0;
    using(var s1xEnumerator = series1X.GetEnumerator())
    using(var s1yEnumerator = series1Y.GetEnumerator())
    using(var s2xEnumerator = series2X.GetEnumerator())
    {
        hasS1 = s1xEnumerator.MoveNext();
        hasS2 = s2xEnumerator.MoveNext();
        s1yEnumerator.MoveNext();
        while(hasS1 && hasS2)
        {
            x1 = s1xEnumerator.Current;
            y1 = s1yEnumerator.Current;
            x = s2xEnumerator.Current;
            
            if (x1 <= x)
            {
                newSeries1X.Add(x1);
                newSeries1Y.Add(y1);
                hasS1 = s1xEnumerator.MoveNext();
                s1yEnumerator.MoveNext();
                preinterp = false;
                if (hasS1)
                {
                    x0 = x1;
                    y0 = y1;
                }
                if (x1 == x)
                {
                    hasS2 = s2xEnumerator.MoveNext();
                }
            }
            else
            {
                // we have to look ahead to get the next interval to interpolate before x0
                if (preinterp)
                {
                    x0 = x1;
                    y0 = y1;
                    x1 = series1X[1]; // can't peek with enumerator
                    y1 = series1Y[1]; 
                    preinterp = false;
                }
                
                y = y0 + (y1 - y0) * (x - x0) / (x1 - x0);
                newSeries1X.Add(x);
                newSeries1Y.Add(y);
                hasS2 = s2xEnumerator.MoveNext();
            }
        }
        
        while(hasS1)
        {
            newSeries1X.Add(s1xEnumerator.Current);
            newSeries1Y.Add(s1yEnumerator.Current);
            hasS1 = s1xEnumerator.MoveNext();
            s1yEnumerator.MoveNext();
        }
        
        while(hasS2)
        {
            x = s2xEnumerator.Current;
            y = y0 + (y1 - y0) * (x - x0) / (x1 - x0);
            newSeries1X.Add(x);
            newSeries1Y.Add(y);
            hasS2 = s2xEnumerator.MoveNext();
        }
    }
