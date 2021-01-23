    public static class MetroHelper
    {
        public static bool ContainsInvariant(this string mainText, string queryText)
        {
            return mainText.ToUpperInvariant().Contains(queryText.ToUpperInvariant());
        }
    }
