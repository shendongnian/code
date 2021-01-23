    [Test]
    public void Test()
    {
        string input = "peace \"this world\" would be 'and then' some";
        MatchCollection matches = Regex.Matches(input, @"(?<=([\'\""])).*?(?=\1)");
        Assert.AreEqual("this world", matches[0].Value);
        Assert.AreEqual("and then", matches[1].Value);
    }
