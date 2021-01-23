    public static DateTime GetFirstDay(int year, int month, DayOfWeek day, int occurance)
    {
        DateTime result = new DateTime(year, month, 1);
        int i = 0;
            
        while (result.DayOfWeek != day || occurance != i)
        {
            result = result.AddDays(1);
            if((result.DayOfWeek == day))
                i++;
        }
        return result;
    }
