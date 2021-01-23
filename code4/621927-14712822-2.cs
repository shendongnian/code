    DateTime date = new DateTime(2013, 1, 1);
    var cal = System.Globalization.CultureInfo.CurrentCulture.Calendar;
    List<String> monthDates = Enumerable.Range(0, cal.GetDaysInMonth(date.Year, date.Month))
        .Select(i => date.AddDays(i).ToString("MMM d"))
        .ToList();
