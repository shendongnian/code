    public void CultureTest()
    {
        var c = CultureInfo.CreateSpecificCulture("nb-NO");
        Assert.AreEqual("Norwegian, Bokmål (Norway)",c.DisplayName);
        Assert.AreEqual("nb-NO", c.Name);
        Assert.AreEqual("norsk, bokmål (Norge)", c.NativeName);
    }
