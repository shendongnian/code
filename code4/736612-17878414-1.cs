        private static bool IsValidISO(string input)
        {
            byte[] bytes = Encoding.GetEncoding("ISO-8859-1").GetBytes(input);
            String result = Encoding.GetEncoding("ISO-8859-1").GetString(bytes);
            return String.Equals(input, result);
        }
