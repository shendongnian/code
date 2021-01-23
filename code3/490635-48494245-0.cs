    public String getLocalDayName( DayOfWeek dayOfweek) {
        var culture = System.Threading.Thread.CurrentThread.CurrentUICulture;
        var format = culture.DateTimeFormat;
        return format.GetDayName(dayOfweek);
    }
