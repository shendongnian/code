    public class StatisticsMap<TKey>
    {
        public StatisticsMap<TKey>(int maxEntries)
        {
             _MaxEntries = maxEntries;
        }
  
        private int _MaxEntries;
        private SortedList<Tuple<Statistics, TKey>> _SortedStatistics;
        private Dictionary<TKey, Statistics> _KeyedStatistics;
        public void Add(TKey key, Statistics stat)
        {
            _SortedStatistics.Add(Tuple.Create(stat, key));
            _KeyedStatistics[key] = stat;
            while (_SortedStats.Count > _MaxEntries)
            {
                 int lastIndex = _SortedStatistics.Count - 1;
                 var doomed = _SortedStatistics[lastIndex];
                 _SortedStatistics.RemoveAt(lastIndex);
                 _KeyedStatistics.Remove(doomed.Item2);
            }
        }
        public Statistics Get(TKey key)
        {
            return _KeyedStatistics[key];
        }
    }
