    public class DataEqualityComparer : IEqualityComparer<Data>
    {
        public bool Equals(Data x, Data y)
        {
            return x != null && y != null && x.Key == y.Key;
        }
        public int GetHashCode(Data obj)
        {
            return obj.Key.GetHashCode();
        }
    }
