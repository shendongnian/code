    [TestMethod]
    public void ReplaceDashByEmptyString()
    {
        string othersWithDash = "Oth-ers";
        string othersWithoutDash = othersWithDash.Replace("-", string.Empty);
        Assert.AreEqual("Others", othersWithoutDash);
    }
