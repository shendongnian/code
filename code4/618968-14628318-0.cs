    public class MyListComparer : IEqualityComparer<List<string>>
    {
        public bool Equals(List<string> x, List<string> y)
        {
            return x.SequenceEqual(y);
        }
        public int GetHashCode(List<string> obj)
        {
            return obj.Sum(item => item.GetHashCode());
        }
    }
