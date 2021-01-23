    public static string NullSafeToString(DateTime? possiblyNullDateTime, string format, string nullString = "")
        {
            return string.Empty;
        }
        public static string NullSafeToString<T>(Nullable<T> nullable, string nullString = "") where T : struct
        {
            return string.Empty;
        }
        static void Test()
        {
            DateTime? datetime = DateTime.Now;
            NullSafeToString(datetime, "yyyyMMdd");
        }
  
