    public static class GoldBishopExtensions
    {
        public static string Quote(this string source, string fallback = null)
        {
            return !String.IsNullOrWhiteSpace(source) 
                       ? String.Format("\"{0}\"", source) 
                       : fallback;
        }
    }
    evt.Name.Quote();
