    public class ListComparer : IEqualityComparer<IList<object>>
    {
        public bool Equals(IList<object> x, IList<object> y)
        {
            if (x == null || y == null) return false;
            return x.SequenceEqual(y);
        }
        public int GetHashCode(IList<object> list)
        {
            if (list == null) return int.MinValue;
            int hash = 19;
            unchecked // Overflow is fine, just wrap
            {
                foreach (object obj in list)
                    hash = hash + obj.GetHashCode();
            }
            return hash;
        }
    }
