    public static DateTime AddBusinessDays(DateTime date, int days)
     {
        if (days == 0) return date;
       if (date.DayOfWeek == DayOfWeek.Saturday)
       {
        date = date.AddDays(2);
        days -= 1;
      }
      else if (date.DayOfWeek == DayOfWeek.Sunday)
      {
        date = date.AddDays(1);
        days -= 1;
      } 
     date = date.AddDays(days / 5 * 7);
     int extraDays = days % 5;
     if ((int)date.DayOfWeek + extraDays > 5)
     {
        extraDays += 2;
     }
    int extraDaysForHolidays =-1;
    //Load holidays from DB into list
    List<DateTime> dates = GetHolidays();
    while(extraDaysForHolidays !=0)
    {
    
     var days =  dates.Where(x => x >= date  && x <= date.AddDays(extraDays)).Count;
     extraDaysForHolidays =days;
     extraDays+=days;  
    }
    return date.AddDays(extraDays);
