    [TestCase("First Second", "Second First")]
    public void NumberedReplaceTest(string input, string expected)
    {
        Regex regex = new Regex("(?<firstMatch>First) (?<secondMatch>Second)");
        Assert.IsTrue(regex.IsMatch(input));
        string replace = regex.Replace(input, ${secondMatch} ${firstMatch});
        Assert.AreEqual(expected, replace);
    }
