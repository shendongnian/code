    static class ExtensionMethods
    {
        public static IEnumerable<string> Extensions(this IEnumerable<string> strs)
        {
            foreach (var str in strs)
            {
                yield return str + "_extension";
            }
        }
    }
