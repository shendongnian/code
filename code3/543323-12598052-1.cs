    public static class DecimalExtensions
    {
        public static string FormatCurrency(this decimal instance)
        {
            var format = new NumberFormatInfo
            {
                CurrencyGroupSeparator = ",",
                CurrencyDecimalDigits = 2,
                CurrencyDecimalSeparator = ".",
                CurrencySymbol = "R"
            };
            return string.Format(format, "{0:C}", instance);
        }
    }
