    [TestMethod]
    public void DecimalEpsilonTest()
    {
        var minDec = new BigInteger(decimal.MinValue);
        var maxDec = new BigInteger(decimal.MaxValue);
        var epsilon = (BigInteger)(maxDec - minDec);
        Console.WriteLine(epsilon);
    }
