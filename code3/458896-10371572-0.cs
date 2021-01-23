    var d = new DateTime(2012, 01, 01);
    System.Globalization.CultureInfo cul = System.Globalization.CultureInfo.CurrentCulture;
    var firstDayWeek = cul.Calendar.GetWeekOfYear(
        d,
        System.Globalization.CalendarWeekRule.FirstDay,
        DayOfWeek.Monday);
    int weekNum = cul.Calendar.GetWeekOfYear(
        d,
        System.Globalization.CalendarWeekRule.FirstFourDayWeek,
        DayOfWeek.Monday);
    int year = firstDayWeek == weekNum ? d.Year : d.Year -1 ;
