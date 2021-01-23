    private int GetDaysInAYear(int year)
    {
       int days = 0;
       for (int i = 1; i <= 12; i++)
       {
           days += DateTime.DaysInMonth(year, i);
       }
      return days;
    } 
