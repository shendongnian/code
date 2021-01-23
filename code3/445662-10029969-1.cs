    public static IList<string> TransformDates(DateTime start, DateTime end)
    {
        List<string> months = new List<string>
        {
            start.ToString("MMM yyyy", 
                    CultureInfo.CreateSpecificCulture("en-US"))
        };
        if (isSplitWeek(start, end))
        {
            months.Add(end.ToString("MMM yyyy", 
                    CultureInfo.CreateSpecificCulture("en-US")));
        }
 
        return months;
    }
...
    var monthlist = data
        .Select(x => new 
        { 
            start =  x.WKENDstart,
            end = x.WKENDstart.AddDays(6)
        })
        .OrderBy(y => y.start )
        .Select(m => new
        {
            monthname = TransformDates(m.start, m.end) // IList<string> 
        })
        .Distinct()
        .ToList();
