    [TestMethod]
    public void RegExTest()
    {
        var rex = new Regex("^T(?<N>[0-9]+):");
        var match = rex.Match("T12:abc");
        Assert.IsTrue(match.Success);
        Assert.IsTrue(match.Groups[0].Success);
        Assert.AreEqual("12", match.Groups["N"].Value);
    }
