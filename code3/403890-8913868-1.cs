    public static class CurrencyExtensions
    {
        public static string AsCurrency(this int value)
        {
            return value.AsCurrency(CultureInfo.CurrentCulture);
        }
        public static string AsCurrency(this int value, CultureInfo culture)
        {
            decimal result = value / 100m;
            return result.ToString("c", culture);
        }
    }
