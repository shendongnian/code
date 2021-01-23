    class StreakAggregator<TKey>
    {
        public Dictionary<TKey, int> Best = new Dictionary<TKey, int>();
        public Dictionary<TKey, int> Current = new Dictionary<TKey, int>();
        public StreakAggregator<TKey> UpdateWith(TKey key, bool success)
        {
            int c = 0;
            Current.TryGetValue(key, out c);
            if (success)
            {
                Current[key] = c + 1;
            }
            else
            {
                int b = 0;
                Best.TryGetValue(key, out b);
                if (c > b)
                {
                    Best[key] = c;
                }
                Current[key] = 0;
            }
            return this;
        }
        public StreakAggregator<TKey> Finalise()
        {
            foreach (TKey k in Current.Keys)
            {
                UpdateWith(k, false);
            }
            return this;
        }
    }
