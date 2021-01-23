    [Test]
    [TestCase("1")]
    [TestCase("2")]
    [TestCase("3.5")]
    [TestCase("3.58278723475")]
    [TestCase("6523424.82347265")]
    public void FluentCalculator_Test(string testSource)
    {
        var match = Regex.Match(testSource, @"^(?:[-+]?[1-9]\d*|0)?(?:\.\d+)?$");
        Assert.IsTrue(match.Success);
    }
