        DateTime Base = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(1).Month, 1);
        
        int x = DateTime.DaysInMonth(Base.Year, Base.Month);
        string[] daysOfMonth = new string[x];
        int i = 0;
        while (Base.Day != x)
        {
            daysOfMonth[i++] = Base.DayOfWeek.ToString();
            Base = Base.AddDays(1);
        }
