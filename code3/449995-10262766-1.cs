    public class ColumnComparer : IEqualityComparer<object[]>
    {
        public bool Equals(object[] x, object[] y)
        {
            return Enumerable.SequenceEqual(x, y);
        }
        public int GetHashCode(object[] obj)
        {
            return (string.Join("", obj.ToArray())).GetHashCode();
        }
    }
