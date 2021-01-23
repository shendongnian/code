    public static DateTime? TryNew(int year,
                                   int month,
                                   int day,
                                   Calendar calendar)
    {
        if (calendar == null)
            calendar = new GregorianCalendar();
        if (year < calendar.MinSupportedDateTime.Year)
            return null;
        if (year > calendar.MaxSupportedDateTime.Year)
            return null;
        // Note that even with this check we can't assert this is a valid
        // month because one year may be "shared" for two eras moreover here
        // we're assuming current era.
        if (month < 1 || month > calendar.GetMonthsInYear(year))
            return null;
    
        if (day <= 0 || day > DateTime.DaysInMonth(year, month))
            return null;
        // Now, probably, date is valid but there may still be issues
        // about era and missing days because of calendar changes.
        // For all this checks we rely on DateTime implementation.        
        try
        {
            return new DateTime(year, month, day, calendar);
        }
        catch (ArgumentOutOfRangeException)
        {
            return null;
        }
    }
