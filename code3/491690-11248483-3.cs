    // The dates don't really matter here... we just want a sample start/end
    // for an opening period
    DateTime open = new DateTime(2000, 1, 1) + openTimespan;
    DateTime close = new DateTime(2000, 1, 1) + closeTimespan;
    if (open > close)
    {
        close = close.AddDays(1);
    }
