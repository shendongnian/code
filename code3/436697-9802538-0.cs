        public static string FormatWithCommaSeperator<T>(T value)
        {
            if (value is int)
            {
                // Do your int formatting here
            }
            else if (value is decimal)
            {
                // Do your decimal formatting here
            }
            return "Parameter 'value' is not an integer or decimal"; // Or throw an exception of some kind?
        }
