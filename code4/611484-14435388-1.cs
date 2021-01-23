    private TimeSpanText = new Dictionary<TimeSpan, string>();
    public Reminders()
    {
        TimeSpanText.Add(TimeSpan.Zero, "None");
        TimeSpanText.Add(new TimeSpan(0, 5, 0), "5 minutes before");
        TimeSpanText.Add(new TimeSpan(0, 15, 0), "15 minutes before");
        TimeSpanText.Add(new TimeSpan(0, 30, 0), "30 minutes before");
        TimeSpanText.Add(new TimeSpan(1, 0, 0), "1 hour before");
        // ....
    }
