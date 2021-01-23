    public static class DateUtil
    {
        public static double? ConvertToDouble(this DateTime? date)
        {
            return date.HasValue ? date.Value.ToOADate() : (double?)null;
        }
    }
