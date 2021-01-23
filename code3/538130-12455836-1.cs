    private static CultureInfo culture = CultureInfo.CreateSpecificCulture("he-IL");
    public static string GetMonthName(string monthNum)
    {
        return culture.DateTimeFormat.GetMonthName(Convert.ToInt32(monthNum));
    }
