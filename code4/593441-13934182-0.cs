    [Test]
    public void ParseUtcDateTimeTest()
    {
        DateTime dateTime = DateTime.Parse("2012-11-20T00:00:00Z", CultureInfo.InstalledUICulture);
        Assert.AreEqual(new DateTime(2012, 11, 20, 01, 00, 00), dateTime);
        DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime);
        Assert.AreEqual(new TimeSpan(0, 1, 0, 0), dateTimeOffset.Offset);
    }
