    DateTime date = new DateTime(2013, 01, 01);
    var days = System.Globalization.CultureInfo.CurrentCulture.Calendar.GetDaysInMonth(2013, 01);
    List<String> monthDates = Enumerable.Range(0, days)
        .Select(i => date.AddDays(i).ToString("MMM d"))
        .ToList();
