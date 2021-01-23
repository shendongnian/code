    [TestCase("{\"message\":\"Sample Message\"}", "Sample Message")]
    [TestCase("{\"New York\" : \"Its in United States\"}", "Its in United States")]
    [TestCase("{\"London\" : \"Its in United Kingdom\"}", "Its in United Kingdom")]
    public void TestNameTest(string json, string expected)
    {
        var result = JObject.Parse(json);
        var value = result.Values().Single();
        var jValue = new JValue(expected);
        Assert.AreEqual( jValue,value);
    }
