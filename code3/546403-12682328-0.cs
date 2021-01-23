    private decimal? ParseOrDefault(string decimalAsString, decimal? defaultIfInvalidString=null)
    {
        decimal result;
        if (decimal.TryParse(decimalAsString, out result))
            return result;
        return defaultIfInvalidString;
    }
    [Test]
    public void ParseOrDefaultTest()
    {
        decimal? actual = ParseOrDefault("12", null);
        Assert.AreEqual(12m,actual);
    
        actual = ParseOrDefault("Invalid string", null);
        Assert.AreEqual(null, actual);
    }
