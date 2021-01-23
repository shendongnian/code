    DateTime Base = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(1).Month, 1);
    int x = DateTime.DaysInMonth(Base.Year, Base.Month);
    while (Base.Day != x)
    {
        Console.WriteLine(Base.DayOfWeek.ToString());
        Base = Base.AddDays(1);
    }
