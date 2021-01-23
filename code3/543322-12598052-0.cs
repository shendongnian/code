    public static class DecimalExtensions
    {
        public static string FormatCurrency(this decimal instance)
        {
            var format = new NumberFormatInfo
            {
                NumberGroupSeparator = ",",
                NumberDecimalDigits = 2,
                NumberDecimalSeparator = "."
            };
            return string.Format(format, "{0:N}", instance);
        }
    }
