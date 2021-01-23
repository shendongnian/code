    public bool TryGetCurrencySymbol(string ISOCurrencySymbol, out string symbol)
    {
    	symbol = CultureInfo
    		.GetCultures(CultureTypes.AllCultures)
    		.Where(c => !c.IsNeutralCulture)
    		.Select(culture => {
    			try{
    				return new RegionInfo(culture.Name);
    			}
    			catch
    			{
    				return null;
    			}
    		})
    		.Where(ri => ri!=null && ri.ISOCurrencySymbol == ISOCurrencySymbol)
    		.Select(ri => ri.CurrencySymbol)
    		.FirstOrDefault();
    	return symbol != null;
    }
