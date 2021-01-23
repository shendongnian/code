    [TestCase(true, true)]
    [TestCase("something else", false)]
    public void IsBoolean_VariousValues_ReturnsCorrectly(object candidate, bool expectedResult)
    {
        Assert.That(BooleanService.IsBoolean(candidate), Is.EqualTo(expectedResult));
    }
