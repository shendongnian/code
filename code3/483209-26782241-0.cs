    public static class StringExtensions
    {
        public static int? AsInt(this string input)
        {
            int number;
            if (int.TryParse(input, out number))
            {
                return number;
            }
            return null;
        }
    }
