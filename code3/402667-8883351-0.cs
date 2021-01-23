    public static class Extensions
    {
        public static DateTime ParseTwitterDateTime(this string date)
        {
            const string format = "ddd MMM dd HH:mm:ss zzzz yyyy";
            return  DateTime.ParseExact(date, format, CultureInfo.InvariantCulture);
        }
        public static DateTime ParseFacebookDateTime(this string date)
        {
            const string format = "ddd, dd MMM yyyy HH:mm:ss zzzz";
            return  DateTime.ParseExact(date, format, CultureInfo.InvariantCulture);
        }
    }
