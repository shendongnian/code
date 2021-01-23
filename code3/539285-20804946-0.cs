    public class StringComparerIgnoreCase : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            if (x != null && y != null)
            {
                return x.ToLowerInvariant() == y.ToLowerInvariant();
            }
            return false;
        }
        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }
