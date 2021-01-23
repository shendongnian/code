    var cal = System.Globalization.CultureInfo.CurrentCulture.Calendar;
    int days = cal.GetDaysInMonth(2013, 01);
    List<String> monthDates = Enumerable.Range(0, days)
        .Select(i => date.AddDays(i).ToString("MMM d"))
        .ToList();
