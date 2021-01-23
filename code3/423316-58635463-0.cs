    static class Extensions
    {
        public static void AddSafe(this Dictionary<int, string> dictionary, int key, string value)
        {
            if (!dictionary.ContainsValue(value))
                dictionary.Add(key, value);
        }
    }
