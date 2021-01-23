    public static class DicExt
    {
        public static TKey GetNthKeyOf<TKey,TValue>(this Dictionary<TKey,TValue> dic, n)
        {
            int i = 0;
            foreach(KeyValuePair kv in dic)
            {
               if (i==n) return kv.Key;
            }
            throw new IndexOutOfRangeException();
        }
    }
