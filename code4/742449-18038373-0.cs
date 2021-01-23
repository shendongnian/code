    public static class ExtensionMethods
    {
        public static bool Any(this IEnumerable t) {
            foreach (var o in t)
                return true;
            return false;
        }
    }
