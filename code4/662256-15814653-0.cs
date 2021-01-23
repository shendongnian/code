    DateTime startdate = DateTime.Parse("2013-04-04");
    DateTime enddate = DateTime.Parse("2014-01-31");
    DateTime parseDate;
    List<DateTime> startings = new List<DateTime>();
    List<DateTime> endings = new List<DateTime>();
    startings.Add(startdate);
    parseDate = startdate.AddMonths(1);
    while(parseDate.Day != 1)
        parseDate=parseDate.AddDays(-1);
    parseDate=parseDate.AddDays(-1);
    endings.Add(parseDate);
    while (parseDate<enddate)
    {
        parseDate = parseDate.AddDays(1);
        startings.Add(parseDate);
        parseDate = parseDate.AddMonths(2);
        parseDate = parseDate.AddDays(-1);
        endings.Add(parseDate);
    }
    endings[endings.Count() - 1] = enddate;
