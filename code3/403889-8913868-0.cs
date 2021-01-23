    public static class CurrencyExtensions
    {
        public static string AsCurrency(this int value)
        {
            decimal result = (decimal)(value / 100.0);
            return result.ToString("c");
        }
    }
