    [Test]
    public void AutoMapper_Configuration_IsValid()
    {
        Mapper.Initialize(m => m.AddProfile<NullProfile>());
        Mapper.AssertConfigurationIsValid();
    }
    [Test]
    public void AutoMapper_DriverMapping_IsValid()
    {
        Mapper.Initialize(m => m.AddProfile<NullProfile>());
        Mapper.AssertConfigurationIsValid();
        var apiDriver = new API.Driver{ familyName = "Dude", givenName = "Cool" };
        var modelDriver = Mapper.Map<API.Driver, Models.Driver>(apiDriver);
        Assert.That(modelDriver, Is.Not.Null);
        Assert.That(modelDriver.FirstName, Is.EqualTo("Cool"));
        Assert.That(modelDriver.LastName, Is.EqualTo("Dude"));
    }
