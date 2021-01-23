    public static class Extensions
    {
        public static TKey GetKey<TKey, TValue>(this Dictionary<TKey, TValue> dict, TValue value)
        {
            int index = dict.Values.ToList().IndexOf(value);
            if (index == -1)
            {
                return default(TKey); //or maybe throw an exception
            }
            return dict.Keys.ToList()[index];
        }
    }
