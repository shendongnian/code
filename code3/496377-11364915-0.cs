    public string PriceInReal
    {
        get
        {
             CultureInfo cultureInfo = CultureInfo.GetCultureInfo("pt-BR");
             return String.Format(cultureInfo, "{0:C}", Price);
        }
    }
