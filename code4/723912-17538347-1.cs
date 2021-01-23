    public static class ExtensionFunctions
    {
        public static bool In<T>(this T v, params T[] vals)
        {
            return vals.Contains(v);
        }
    }
