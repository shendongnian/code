    [TestCase(6, "GBP", "British Pound", "£")]
    public void CanGetCurrencyById(int id, string code, string name, string symbol)
    {
        ICurrencyRepo currencies = new RepoFactory().CreateCurrencyRepo(_session);
        Currency c = currencies.GetById<Currency>(id);
        Assert.That(c, Is.EqualTo(new Currency(code, name, symbol)));
    }
