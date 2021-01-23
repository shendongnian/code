    TimeSpan ts = new TimeSpan();
    DateTime dt = new DateTime();
    TimeSpan day = dt.AddDays(1) - dt;
    TimeSpan minute = dt.AddMinutes(1) - dt;
    
    for (int i = 0; i < 20000; i++)
    {
         ts = ts.Add(minute);
         if (ts.TotalDays > 1)
         {
             ts = ts.Subtract(day);
         }
    }
