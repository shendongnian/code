    public static TimeSpan GetTimeSpan(DateTime startTime, DateTime endTime)
    {
        TimeSpan totTime = new TimeSpan();
        startTime = Convert.ToDateTime(startTime.TimeOfDay.ToString());
        endTime = Convert.ToDateTime(endTime.TimeOfDay.ToString());
        totTime = (TimeSpan)(endTime - startTime);
        return totTime;
        // or you can return totTime.TotalSeconds
    }
