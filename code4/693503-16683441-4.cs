    var count = dates.Count;
    double temp = 0D;
    for (int i = 0; i < count; i++)
    {
        temp += dates[i].Ticks / (double)count;
    }
    var average = new DateTime((long)temp);
