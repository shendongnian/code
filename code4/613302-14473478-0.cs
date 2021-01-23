    public class KeyComparer : IEqualityComparer<KeyValuePair<string, int>>
    {
        public bool Equals(KeyValuePair<string, int> x, KeyValuePair<string, int> y)
        {
            return x.Key.Equals(y.Key);
        }
        public int GetHashCode(KeyValuePair<string, int> obj)
        {
            return obj.Key.GetHashCode();
        }
    }
