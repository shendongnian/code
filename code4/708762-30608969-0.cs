    public static class DictionaryExt
    {
        public static string ToQueryString<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
            return ToQueryString<TKey, TValue>(dictionary, "?");
        }
        public static string ToQueryString<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, string startupDelimiter)
        {
            string result = string.Empty;
            foreach (var item in dictionary)
            {
                if (string.IsNullOrEmpty(result))
                    result += startupDelimiter; // "?";
                else
                    result += "&";
                result += string.Format("{0}={1}", item.Key, item.Value);
            }
            return result;
        }
    }
