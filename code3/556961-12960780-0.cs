    namespace MyNamespace
    {
        public static class StringExtensions
        {
            public static bool IsDouble(this string value)
            {
                double outDouble;
                return Double.TryParse(value, out outDouble);
            }
        }
    }
