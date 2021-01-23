    public List<String> GetLocalizedDayOfWeekValues(CultureInfo culture)
    {
		return GetLocalizedDayOfWeekValues(culture, culture.DateTimeFormat.FirstDayOfWeek);
    }
    public List<String> GetLocalizedDayOfWeekValues(CultureInfo culture, DayOfWeek startDay)
    {
    	string[] dayNames = culture.DateTimeFormat.DayNames;
    	IEnumerable<string> query = dayNames
			.Skip((int) startDay)
			.Concat(
				dayNames.Take((int) startDay)
			);
        return query.ToList();
    }
