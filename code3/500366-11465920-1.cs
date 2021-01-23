    // using System.Globalization;
    var calendar = CultureInfo.CurrentCulture.Calendar;
    var firstDayOfWeek = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
    var weekPeriods =
    Enumerable.Range(1, calendar.GetDaysInMonth(year, month))
              .Select(d =>
              {
                  var date = new DateTime(year, month, d);
                  var weekNumInYear = calendar.GetWeekOfYear(date, CalendarWeekRule.FirstDay, firstDayOfWeek);
                  return new { date, weekNumInYear };
              })
              .GroupBy(x => x.weekNumInYear)
              .Select(x => new { DateFrom = x.First().date, To = x.Last().date })
              .ToList();
