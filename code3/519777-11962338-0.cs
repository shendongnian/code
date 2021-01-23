    public static DateTime TimeRoundUp(DateTime dt, int Interval)
    {
        int nextMin = (int)(dt.Minute / Interval);
        int lowerEdge = nextMin * Interval;
        int upperEdge = lowerEdge + Interval;
        if (dt.Minute - lowerEdge < upperEdge - dt.Minute)
        {
            nextMin = lowerEdge - dt.Minute;
        }
        else
        {
            nextMin = upperEdge - dt.Minute;
        }
        if (nextMin > 59)
        {
            nextMin = 60 - dt.Minute;
        }
        dt = dt.AddMinutes(nextMin);
        dt = dt.AddSeconds(-dt.Second); // zero seconds
        return dt;
    }
