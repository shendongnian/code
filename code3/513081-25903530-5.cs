    [TestMethod]
    public void RealEpsilonTest()
    {
        var dec1 = Decimal.Parse("1.0");
        var dec2 = Decimal.Parse("1.00");
        Console.WriteLine(BitPrinter.Print(dec1, " "));
        Console.WriteLine(BitPrinter.Print(dec2, " "));
    }
