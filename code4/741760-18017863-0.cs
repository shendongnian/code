    TimeSpan DoubleToTimeSpan(double time)
    {
        string str = time.ToString("F2", CultureInfo.InvariantCulture);
        TimeSpan ts = TimeSpan.ParseExact(str, "h'.'mm", CultureInfo.InvariantCulture);
        return ts;
    }
