    public static class IntExtensions
    {
        public static string ToHex(this int source)
        {
            return string.Format("{0:X}", source);
        }
    }
