    const string dateString = "2012-11-20T00:00:00Z";
    var timezone = TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"); //this timezone has an offset of +01:00:00 on this date
    var utc = DateTimeOffset.Parse(dateString);
    var result = TimeZoneInfo.ConvertTime(utc, timezone);
            
    Assert.AreEqual(result.Offset, new TimeSpan(1, 0, 0));  //the correct utc offset, in this case +01:00:00
    Assert.AreEqual(result.UtcDateTime, new DateTime(2012, 11, 20, 0, 0, 0)); //equals the original date
    Assert.AreEqual(result.DateTime, new DateTime(2012, 11, 20, 1, 0, 0));
