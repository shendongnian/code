    public static decimal ToDecimalFromStringDecimalOrMoneyFormattedDecimal(this string s)
    {
        try
        {
            return decimal.Parse(s);
        }
        catch
        {
            var numberWithoutMoneyFormatting = Regex.Replace(s, @"[^\d.-]", "");
            return decimal.Parse(numberWithoutMoneyFormatting);
        }
    }
    [Test]
    public void Test_ToDecimalFromStringDecimalOrMoneyFormattedDecimal()
    {
        Assert.That("$ 500".ToDecimalFromStringDecimalOrMoneyFormattedDecimal() == (decimal)500);
        Assert.That("R -500".ToDecimalFromStringDecimalOrMoneyFormattedDecimal() == (decimal)-500);
        Assert.That("-$ 500".ToDecimalFromStringDecimalOrMoneyFormattedDecimal() == (decimal)-500);
        Assert.That("P 500.90".ToDecimalFromStringDecimalOrMoneyFormattedDecimal() == (decimal)500.9);
        Assert.That("$ -50 0,090,08.08".ToDecimalFromStringDecimalOrMoneyFormattedDecimal() == (decimal)-50009008.08);
    }
