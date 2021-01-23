    public bool ValidateCurrency(string price, string cultureCode)
    {
        decimal test;
        return decimal.TryParse
           (price, NumberStyles.Currency, new CultureInfo(cultureCode), out test);
    }
    if (!ValidateCurrency(price, "en-GB"))
    {
        //error
    }
