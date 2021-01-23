     public static class Ext
    {
        public static double? AsLocaleDouble(this string str)
        {
            var result = double.NaN;
            var format = Thread.CurrentThread.CurrentUICulture.NumberFormat;
            double.TryParse(str, NumberStyles.AllowDecimalPoint, format, out result);
            return result;
        }
    }
