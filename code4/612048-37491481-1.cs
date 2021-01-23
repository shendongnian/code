    public static class DateTimeExtensions
    {
        public static bool MinValue(this DateTime input)
        {
            if (input == new DateTime(1900, 1, 1))
            {
                return true;
            }
            return false;
        }
    }
