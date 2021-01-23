    DateTime Base = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(1).Month, 1);
    List<String> Days = new List<String>();
    int x = DateTime.DaysInMonth(Base.Year, Base.Month);
    while (Base.Day != x)
    {
        Days.Add(Base.DayOfWeek.ToString());
        Base = Base.AddDays(1);
    }
