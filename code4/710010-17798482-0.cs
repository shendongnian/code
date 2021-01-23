    TimeSpan ts = new TimeSpan();
    
    for (int tCount = 0; tCount < 1001; tCount++)
    {
        DateTime then = DateTime.Now;
    
        METHOD_TO_TEST()
    
        DateTime nNow = DateTime.Now;
        TimeSpan tt = nNow - then;
        ts += tt;
    }
    
    return (float)ts.Ticks / (float)(tCount - 1);
