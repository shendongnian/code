    [TestCase(true)]
    [TestCase("tRuE")]
    [TestCase(false)]
    public void IsBoolean_ValidBoolRepresentations_ReturnsTrue(object candidate)
    {
        Assert.That(BooleanService.IsBoolean(candidate), Is.True);
    }
    [TestCase("-3.14")]
    [TestCase("something else")]
    [TestCase(7)]
    public void IsBoolean_InvalidBoolRepresentations_ReturnsFalse(object candidate)
    {
        Assert.That(BooleanService.IsBoolean(candidate), Is.False);
    }
