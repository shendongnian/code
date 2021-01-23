    // 1. Convert your string list to datetimes  
    IEnumerable<DateTime> dates = nameList.Select(m => DateTime.Parse(m, yourFormatProvider));
        
    // 2. Get first and last date
    DateTime maxDate = dates.Max();
    DateTime minDate = dates.Min();
