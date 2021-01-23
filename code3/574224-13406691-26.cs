    [Test]
    public void AutoMapper_Configuration_IsValid()
    {
        Mapper.Initialize(m => m.AddProfile<MVCF1Profile>());
        Mapper.AssertConfigurationIsValid();
    }
    [Test]
    public void AutoMapper_DriverMapping_IsValid()
    {
        Mapper.Initialize(m => m.AddProfile<MVCF1Profile>());
        Mapper.AssertConfigurationIsValid();
        // Convert JSON string from question to RootObject instance
        var data = GetData();
        var ds = data.MRData.StandingsTable.StandingsLists.First();
        var driverResults = Mapper.Map<StandingsList, Models.DriverResults>(ds);
        Assert.That(driverResults, Is.Not.Null);
        Assert.That(driverResults.Points, Is.Null);
        Assert.That(driverResults.Season, Is.EqualTo("2012"));
        Assert.That(driverResults.Driver, Is.Not.Null);
        Assert.That(driverResults.Driver.Count(), Is.EqualTo(25));
    }
