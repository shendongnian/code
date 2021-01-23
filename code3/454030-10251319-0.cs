    public static class StringExtensions
        {
            // This is only need for versions before 4.0
            public static bool IsNullOrWhiteSpace(this string value)
            {
                if (value == null) return true;
                return string.IsNullOrEmpty(value.Trim());
            }
        }
