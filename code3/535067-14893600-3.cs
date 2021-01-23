    public string getCurrencySymbol(string CurrencyCode)    
    {
            string symbol = string.Empty;
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            IList Result = new ArrayList();
            foreach (CultureInfo ci in cultures)
            {
                RegionInfo ri = new RegionInfo(ci.LCID);
                if (ri.ISOCurrencySymbol == CurrencyCode)
                {
                    symbol = ri.CurrencySymbol;
                    return symbol;
                }
            }
            return symbol;
    
        }
