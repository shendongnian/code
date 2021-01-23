    var now = DateTime.Now;
    var culture = System.Globalization.CultureInfo.CurrentCulture;
    String[] thisMonthDays = 
         Enumerable.Range(1, culture.Calendar.GetDaysInMonth(now.Year, now.Month))
                   .Select(day => new DateTime(now.Year, now.Month, day))
                   .Select(date => culture.DateTimeFormat.GetDayName(date.DayOfWeek))
                   .ToArray();
