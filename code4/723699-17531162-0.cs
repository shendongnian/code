    public static class GoldBishopExtensions
    {
        public static string Transform(this string source, Func<string, string> transform, string fallback = null)
        {
            return !String.IsNullOrWhiteSpace(source) ? transform(source) : fallback;
        }
    }
