    public static class ExtensionMethod 
    {
        public static IDictionary<int, string> ToDictionary(this string[] array)
        {
            return array
                .Select((k, v) => new { Key = k, Value = v})
                .ToDictionary(x => x.Key, x => x.Value);
        }
    }
