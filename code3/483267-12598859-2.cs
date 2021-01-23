    //Function return First day in Month For Date --example : 01-09-2012
 
    public static  DateTime FirstDayOfMonthFromDateTime(DateTime dateTime)
         {
             return new DateTime(dateTime.Year, dateTime.Month, 1);
            
         }
    //code used to loop throw a Date range for each month
    DateTime FirstDayInMonth = FirstDayOfMonthFromDateTime(Date);
    DateTime TempDay = FirstDayInMonth;
    int days = DateTime.DaysInMonth(FirstDayInMonth.Year, FirstDayInMonth.Month);
       
    for (int i = 0; i < days; i++)
       {
         System.Out.Println(TempDay.toString());
         TempDay.AddDays(1);
       }
    //then used code for each month in year (simple loop from 1-12)..
