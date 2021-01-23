    static class SortedListExtensions
    {
        public static TValue GetNextValueOrDefault<TKey, TValue>(this SortedList<TKey, TValue> list, TKey key)
        {
            var indexOfKey = list.IndexOfKey(key);
            if (indexOfKey == -1)
                return default(TValue);
            if (++indexOfKey == list.Count)
                return default(TValue);
            return list.Values[indexOfKey];
        }
    }
    var myList = new SortedList<int, string>
    {
        { 1, "Hello" },
        { 4, "World" },
        { 7, "Foo" },
        { 9, "Bar" },
    };
    Console.WriteLine(myList.GetNextValueOrDefault(7)); // "Bar"
    Console.WriteLine(myList.GetNextValueOrDefault(9)); // null
