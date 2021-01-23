    public static class Extensions
    {
        public static string ToHex(this int source)
        {
            return string.Format("{0:X}", source);
        }
    }
