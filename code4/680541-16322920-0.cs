    public class EventCollection
    {
        private readonly Dictionary<string, HashSet<DateTime>> _Events = new Dictionary<string, HashSet<DateTime>>();
        public void Add(string key, DateTime value)
        {
            HashSet<DateTime> values;
            if (!_Events.TryGetValue(key, out values))
            {
                values = new HashSet<DateTime>();
                _Events.Add(key, values);
            }
            values.Add(value);
        }
        public IList<KeyValuePair<string, DateTime>> GetOldEvents(bool autoRemove)
        {
            DateTime old = DateTime.Now - TimeSpan.FromHours(8);
            List<KeyValuePair<string, DateTime>> results = new List<KeyValuePair<string,DateTime>>();
            foreach(KeyValuePair<string, HashSet<DateTime>> pair in _Events)
                foreach (DateTime value in pair.Value)
                    if (value < old)
                        results.Add(new KeyValuePair<string, DateTime>(pair.Key, value));
            // Clean up
            if (autoRemove)
            {
                foreach(KeyValuePair<string, DateTime> pair in results)
                {
                    HashSet<DateTime> values = _Events[pair.Key];
                    values.Remove(pair.Value);
                    if (values.Count == 0)
                        _Events.Remove(pair.Key);
                }
            }
            
            return results;
        }
    }
