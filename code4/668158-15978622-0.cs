        public static string ToBase64Url(this string value)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            return HttpUtility.UrlEncode(Convert.ToBase64String(bytes));
        }
        public static string FromBase64Url(this string value)
        {
            string result = HttpUtility.UrlDecode(value);
            byte[] bytes = Convert.FromBase64String(result);
            return Encoding.UTF8.GetString(bytes);
        }
