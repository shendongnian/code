    DateTime d;
    string dateString = "Tuesday May 1, 2012 9:00 AM";
    return DateTime.TryParseExact(
       dateString,
       "dddd MMMM d, yyyy h:mm tt",
       System.Globalization.CultureInfo.CurrentCulture,
       System.Globalization.DateTimeStyles.None,
       out d
    );
