    CultureInfo ci = CultureInfo.GetCultureInfo("sl-SI");
    string[] fmts = ci.DateTimeFormat.GetAllDateTimePatterns();
    
    if (DateTime.TryParseExact(date, fmts, ci, DateTimeStyles.AssumeLocal, out dt))
    {
        DateTime = Convert.ToDateTime(date);
        Check = true;
    }
