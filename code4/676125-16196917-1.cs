    DateTime startDate = DateTime.MinValue;
    DateTime endDate = DateTime.MaxValue;
    // Set this to your culture if it's not en-US
    DateTimeFormatInfo usDtfi = new CultureInfo("en-US", false).DateTimeFormat;
    try { startDate = Convert.ToDateTime(Request.Form["start_date"], usDtfi); }
    catch {}
    
    try { endDate = Convert.ToDateTime(Request.Form["end_date"], usDtfi); }
    catch {}
    if (startDate != DateTime.MinValue && endDate != DateTime.MaxValue)
    {
        query = query.where(add=>add.Date <= endDate && add.Date >= startDate ) //equivalent to between
    }
