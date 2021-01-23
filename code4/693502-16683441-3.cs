    var count = dates.Count;
    long temp = 0L;
    for (int i = 0; i < count; i++)
    {
        temp += dates[i].Ticks / count;
    }
    var average = new DateTime(temp);
