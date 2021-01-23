    DateTime today = DateTime.Today;
    DateTime later = today.AddDays(20);
    
    string todayAsString = today.ToString("d");
    string laterAsString = later.ToString("d");
    
    int daysThisMonth = DateTime.DaysInMonth(today.Year, today.Month);
    int daysLaterMonth = DateTime.DaysInMonth(later.Year, later.Month);
