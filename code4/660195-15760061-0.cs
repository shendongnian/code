    [TestMethod]
    public void Morning_slot_starts_at_nine_am()
    {
        var expected = DateTime.ParseExact("9:00 AM", "h:mm tt", CultureInfo.InvariantCulture);
        var techDay = new TechDay();
        var actual = techDay.MorningSlot.StartTime;
        Assert.AreEqual(expected, actual);
    }
