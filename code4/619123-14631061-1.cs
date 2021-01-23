    public class ObjectArrayComparer : IEqualityComparer<object[]>
    {
        public bool Equals(object[] x, object[] y)
        {
            return object.ReferenceEquals(x, y) || (x != null && y != null && x.SequenceEqual(y));
        }
        public int GetHashCode(object[] obj)
        {
            if (obj == null)
                return 0;
            return unchecked(obj.Select(o => o.GetHashCode()).Aggregate(0, (a, b) => a + b));
        }
    }
