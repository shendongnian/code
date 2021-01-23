    double[] spline_x = { 0D, 5D, 12D, 34D, 100D };
    int i = Array.BinarySearch(spline_x, 25);
    if (i >= 0)
    {
        // your number is in array
    }
    else
    {
        int indexOfNearest = ~i;
        
        if (indexOfNearest == spline_x.Length)
        {
            // number is greater that last item
        }
        else if (indexOfNearest == 0)
        {
            // number is less than first item
        }
        else
        {
            // number is between (indexOfNearest - 1) and indexOfNearest
        }     
    }
