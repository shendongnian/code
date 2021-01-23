    public static DateTime convertDecimal(string strgDate)
    {
        return DateTime.ParseExact(strgDate, "yyyy-MM-dd",
                        System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None));
    }
