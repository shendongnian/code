    private static string TranslateDay(string dayInStringFormat, string culture)
    {
        try
        {
            return CultureInfo.CreateSpecificCulture(culture).DateTimeFormat
                .GetDayName((DayOfWeek)Enum.Parse(typeof(DayOfWeek), dayInStringFormat));
        }
        catch (Exception)
        {
            return null;
        }
    }
