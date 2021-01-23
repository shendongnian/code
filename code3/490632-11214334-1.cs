    public static List<String> GetLocalizedDayOfWeekValues(CultureInfo culture)
    {
		return GetLocalizedDayOfWeekValues(culture, culture.DateTimeFormat.FirstDayOfWeek);
    }
    public static List<String> GetLocalizedDayOfWeekValues(CultureInfo culture, DayOfWeek startDay)
    {
        var formatInfo = culture.DateTimeFormat;
    	var dayNames = formatInfo.DayNames;
    	var query = dayNames
			.Skip((int) startDay)
			.Concat(
				dayNames.Take((int) startDay)
			);
        return query.ToList();
    }
