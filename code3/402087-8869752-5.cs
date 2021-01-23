    [TestCase(6, Result = "GBP")]
    [TestCase(7, Result = "USD")]
    [TestCase(8, Result = "CAD")]
    public string CanGetCurrencyById(int id)
    {
        ICurrencyRepo currencies = new RepoFactory().CreateCurrencyRepo(_session);
        Currency c = currencies.GetById<Currency>(id);
        return c.Code;
    }
