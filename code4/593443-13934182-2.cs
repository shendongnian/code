    [Test]
    public void ConvertTimeTest()
    {
        DateTime dateTime = DateTime.Parse("2012-11-20T00:00:00Z");
        TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard     Time");
        DateTime convertedTime = TimeZoneInfo.ConvertTime(dateTime, cstZone);
        Assert.AreEqual(new DateTime(2012, 11, 19, 18, 00, 00), convertedTime);
        TimeSpan baseUtcOffset = cstZone.BaseUtcOffset;
        Assert.AreEqual(new TimeSpan(0, -6, 0, 0), baseUtcOffset);
    }
