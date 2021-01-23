    List<string> list = new List<string>();
    DateTimeFormatInfo dtFI = new DateTimeFormatInfo();
    DateTime currentDate = DateTime.Now;
    DateTime nextyearDate = currentDate.AddYears(1).AddDays(-1);
    while (currentDate < nextyearDate)
    {
        list.Add(dtFI.GetMonthName(currentDate.Month));
        currentDate = currentDate.AddMonths(1);
    }
