    public static StringExtensions
    {
        public static Boolean IsNotNullAndEquals(this string str1, string str2)
        {
            return !string.IsNullOrEmpty(str1) && str1.Equals(str2)
        }
    }
