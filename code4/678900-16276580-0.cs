      public static class Ext
    {
 
        public static string AsLocaleDateString(this DateTime dt)
        {
            var format = Thread.CurrentThread.CurrentUICulture.DateTimeFormat;
            return dt.ToString(format.ShortDatePattern);
        }
        public static DateTime? AsLocaleDate(this string str)
        {
            if (str.IsNullEmpty())
            {
                return null;
            }
            var format = Thread.CurrentThread.CurrentUICulture.DateTimeFormat;
            return DateTime.ParseExact(str, format.ShortDatePattern, CultureInfo.InvariantCulture, DateTimeStyles.None);
        }
    }
