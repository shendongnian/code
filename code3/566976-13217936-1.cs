    [TestCase("2012-1-2 3:4:5", 2012, 1, 2, 3, 4, 5)]
    [TestCase("2012-10-31 10:59:59", 2012, 10, 31, 10, 59, 59)]
    [TestCase("2012-10-31 23:59:59", 2012, 10, 31, 23, 59, 59)]
    public void ParseExactTest2(string dateTimeString, int year, int month, int day, int hour, int minute, int second)
    {
        DateTime actual = DateTime.ParseExact(dateTimeString, "yyyy-M-d H:m:s", CultureInfo.InvariantCulture, DateTimeStyles.None);
        DateTime expected = new DateTime(year, month, day, hour, minute, second);
        Assert.AreEqual(expected, actual);
    }
