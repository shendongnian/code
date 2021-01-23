    public static class CultureInfoExtensions
    {
        public static bool StartsWithCurrencySymbol(this CultureInfo culture)
        {
            bool startsWithCurrencySymbol = 
                culture.NumberFormat.CurrencyPositivePattern == 0 ||
                culture.NumberFormat.CurrencyPositivePattern == 2;
            return culture.TextInfo.IsRightToLeft ? !startsWithCurrencySymbol : startsWithCurrencySymbol;
        }
    }
