    [TestMethod]
    public void UnitTestThat()
    {
        Assert.AreEqual(@"[[]Hello World[]]", Regex.Replace("[Hello World]", @"[\[\]]", "[$0]"));
    }
