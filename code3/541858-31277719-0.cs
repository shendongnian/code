    using Windows.Globalization;
    using Windows.Globalization.DateTimeFormatting;
    private string FormatDate(int year, int month, int day)
    {
        GeographicRegion userRegion = new GeographicRegion();
        string regionCode = userRegion.CodeTwoLetter;
        var formatter = new DateTimeFormatter("year month day", new[] { regionCode });
        DateTime dateToFormat = new DateTime(year, month, day);
        var formattedDate = formatter.Format(dateToFormat);
        return formattedDate;
    }
