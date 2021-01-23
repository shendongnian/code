    int month = 1;
    int year = 2013;
    var cal = System.Globalization.CultureInfo.CurrentCulture.Calendar;
    IEnumerable<int> daysInMonth = Enumerable.Range(1, cal.GetDaysInMonth(year, month));
  
    List<Tuple<int, DateTime, DateTime>> listOfWorkWeeks = daysInMonth
        .Select(day => new DateTime(year, month, day))
        .GroupBy(d => cal.GetWeekOfYear(d, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday))
        .Select(g => Tuple.Create(g.Key, g.First(), g.Last(d => d.DayOfWeek != DayOfWeek.Saturday && d.DayOfWeek != DayOfWeek.Sunday)))
        .ToList();
    // Item1 = week in year, Item2 = first day, Item3 = last working day
    int weekNum = 1;
    foreach (var weekGroup in listOfWorkWeeks)
    {
        Console.WriteLine("Week{0} = {1} {2} to {1} {3}"
            , weekNum++
            , System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month)
            , weekGroup.Item2.Day
            , weekGroup.Item3.Day);
    }
