    for (System.DateTime d = fromDate; d <= endDate; d = d.AddDays(1))
    {
         DateTime copy = d;
         System.Threading.ThreadPool.QueueUserWorkItem(
                new System.Threading.WaitCallback(day => ProcessOneDay(copy)));
    }
