    public static String ArrayToString(Array array)
    {
        var useComma = true;
        var stringBuilder = new StringBuilder();
        foreach (var value in array)
        {
            if (useComma)
            {
                stringBuilder.AppendFormat("{0}{1}", value, ",");
            }
            else
            {
                stringBuilder.AppendFormat("{0}{1}", value, " ");
            }
            useComma = !useComma;
        }
        // Remove last space or comma
        stringBuilder.Length = stringBuilder.Length - 1;
        return stringBuilder.ToString();
    }
    [TestMethod]
    public void ArrayToStringTest()
    {
        var expectedStringValue =
            "99.28099822998047,68.375 118.30699729919434,57.625 126.49999713897705,37.875 113.94499683380127,11.048999786376953 96.00499725341797,8.5";
        var array = new[]
            {
                "99.28099822998047",
                "68.375",
                "118.30699729919434",
                "57.625",
                "126.49999713897705",
                "37.875",
                "113.94499683380127",
                "11.048999786376953",
                "96.00499725341797",
                "8.5",
            };
        var actualStringValue = ArrayToString(array);
        Assert.AreEqual(expectedStringValue, actualStringValue);
    }
