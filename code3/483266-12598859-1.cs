       DateTime FirstDayInMonth = FirstDayOfMonthFromDateTime(Date);
             DateTime TempDay = FirstDayInMonth;
             int days = DateTime.DaysInMonth(FirstDayInMonth.Year, FirstDayInMonth.Month);
       
    for (int i = 0; i < days; i++)
       {
         System.Out.Println(TempDay.toString());
         TempDay.AddDays(1);
       }
