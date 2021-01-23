    int minutes = 159000;
    TimeSpan t = new TimeSpan(0, minutes, 0);
    
    String HOURS = Math.Round(t.TotalHours, 0).ToString();
    if (HOURS.Length==1)
    {
        HOURS = "0"+HOURS;
    }
    
    
    String MINUTES = t.Minutes.ToString();
    if (MINUTES.Length == 1)
    {
        MINUTES = "0" + MINUTES;
    }
    
    
    String RESULT = HOURS + ":" + MINUTES;
