    public class ListEqualityComparer : IEqualityComparer<List<B>>
    {
        public bool Equals(List<B> x, List<B> y)
        {
            // you can also implement IEqualityComparer<B> and use the overload
            return x.SequenceEqual(y);
        }
        public int GetHashCode(List<B> obj)
        {
            return obj.GetHashCode();
        }
    }
