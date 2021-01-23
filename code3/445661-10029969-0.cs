    public static string TransformDate(DateTime date)
    {
        return date.ToString("MMM yyyy", 
                CultureInfo.CreateSpecificCulture("en-US"))
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
            monthname = string.Format(
                CultureInfo.InvaiarantCulture, 
                "{0}{1}",
                TransformDate(m.start),
                isSplitWeek(m.start, m.end) ? " - " + TransformDate(m.end) : string.Empty 
        })
        .Distinct()
        .ToList();
