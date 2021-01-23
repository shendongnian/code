    public class CusComparer : IEqualityComparer<List<int>>
    {
        public bool Equals(List<int> x, List<int> y)
        {
            return x.SequenceEqual(y);
        }
        public int GetHashCode(List<int> obj)
        {
            return obj.Aggregate(0, (current, item) => current ^ item.GetHashCode());
        }
    }
