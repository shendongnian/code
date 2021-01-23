    public static DateTime PersianDateToJulianDate(DateTime persianDate)
    {
        PersianCalendar pc = new PersianCalendar();
        return new DateTime(persianDate.Year, persianDate.Month, persianDate.Day, pc);
    }
    public static DateTime JulianDateToPersianDate(DateTime persianDate)
    {
        PersianCalendar pc = new PersianCalendar();
        return new DateTime(pc.GetYear(persianDate),
                             pc.GetMonth(persianDate),
                             pc.GetDayOfMonth(persianDate));
    }
