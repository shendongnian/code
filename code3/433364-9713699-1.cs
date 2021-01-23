    static class EnumerableExt
    {
        public static IEnumerable<DictionaryEntry> Entries(this IDictionary dict)
        {
            foreach (var item in dict) yield return (DictionaryEntry)item;
        }
    }
