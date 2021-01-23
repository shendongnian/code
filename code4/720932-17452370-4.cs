    public class YourClass
    {
        private Dictionary<int, List<int>> _dictionary = new Dictionary<int, List<int>>();
        public void AddItem(int key, int value)
        {
            List<int> values;
            if (!_dictionary.TryGetValue(key, out values))
            {
                values = new List<int>();
                _dictionary.Add(key, values);
            }
        
            values.Add(value);
        }
        public IEnumerable<int> GetValues(int key)
        {
            List<int> values;
            if (!_dictionary.TryGetValue(key, out values))
            {
                return new int[0];
            }
        
            return values;
        }
    }
