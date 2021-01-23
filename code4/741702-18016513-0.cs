    void Main()
    {
    	var dict = new Dictionary<string, int>();
    	dict.SetOrIncrement("qwe", 1);
    }
    
    // Define other methods and classes here
    public static class ExtensionMethods
    {
        public static int SetOrIncrement<TKey>(this Dictionary<TKey, int> dict, TKey key, int set)
    	{
            int value;
            if (!dict.TryGetValue(key, out value)) {
               dict.Add(key, set);
               return set;
            }
            dict[key] = ++value;
            return value;
        }
    }
