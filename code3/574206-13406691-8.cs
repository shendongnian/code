    [Test]
    public void AutoMapper_Configuration_IsValid()
    {
        Mapper.Initialize(m => m.AddProfile<MVCF1Profile>());
        Mapper.AssertConfigurationIsValid();
    }
