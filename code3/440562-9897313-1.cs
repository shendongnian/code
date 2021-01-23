    DateTime cellValue = DateTime.Now;
    var beginweek = DateTime.Now.Date.AddDays( (int)DateTime.Now.DayOfWeek *-1);
    var endweek = beginweek.AddDays(6);
    if (cellValue.Date >= beginweek.Date && cellValue.Date <= endweek.Date)
    {
        //do something
    }
