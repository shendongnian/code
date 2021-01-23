    public static class DoubleExtensions
    {
        public static string ToMillionString(this double value)
        {
            return (value * 1000000.0).ToString("#,##0,,", CultureInfo.InvariantCulture);
        }
    }
