    DateTime Base = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(1).Month, 1);
    int x = DateTime.DaysInMonth(Base.Year, Base.Month);
    String[] StringArray = new String[x];
    while (Base.Day != x)
    {
        daysOfMonth[Base.Day - 1] = Base.DayOfWeek.ToString();
        Base = Base.AddDays(1);
    }
