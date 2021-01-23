    [TestCase("11/08/1995", Result= true)]
    [TestCase("1-1", Result = false)]
    [TestCase("1/1", Result = false)]
    public bool IsValidDateTimeTest(string dateTime)
    {
        string[] formats = { "MM/dd/yyyy" };
        DateTime parsedDateTime;
        return DateTime.TryParseExact(dateTime, formats, new CultureInfo("en-US"),
                                       DateTimeStyles.None, out parsedDateTime);
    }
