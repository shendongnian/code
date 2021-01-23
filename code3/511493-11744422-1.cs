    public static class Extensions
    {
        public static string ToStringNoTruncate(this double me, int decimalplaces = 1)
        {
            string result = me.ToString();
            char dec = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            return result.Substring(0, result.LastIndexOf(dec) + decimalplaces + 1);
        }
    }
