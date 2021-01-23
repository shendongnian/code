    public static class ConversionExtensions
    {
        public static int? ToInt32(this string input)
        {
            int value;
            if (!int.TryParse(input, out value) && !string.IsNullOrEmpty(input))
            {
                // this is some weird input that 
                // I may need to handle
                return null;
            }
            return value;
        }
    }
