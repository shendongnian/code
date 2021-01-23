    public IQueryable<Currency> ActiveCurrencies 
    {
        get 
        {
            db.Currencies.Where(c => c.IsActive);
        }
    }
