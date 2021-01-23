    static class CurrencySymbolHelper
    {
        public static string GetCurrencySymbol(CultureInfo cultureInfo, bool getAlternate)
        {
            if (cultureInfo.Name == "ro-RO" && getAlternate)
                    return "EUR";
            return cultureInfo.NumberFormat.CurrencySymbol;
        }
    }
