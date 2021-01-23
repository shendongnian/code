    [Test]
    public void RegexTest()
    {
        var regex = new Regex(@"\b(\w+)\s+(?!\1\b)");
        var str1 = @"aaa aaa aaa";
        Assert.IsFalse(regex.IsMatch(str1)); // no
        var str2 = @"aaa bbb aaa";
        Assert.IsTrue(regex.IsMatch(str2)); // yes
    }
