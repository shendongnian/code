    public class ArrayComparer<T> : EqualityComparer<IEnumerable<T>>
    {
        public override bool Equals(IEnumerable<T> x, IEnumerable<T> y)
        {
            return x != null && y != null &&
                (x == y || Enumerable.SequenceEqual(x,y));
        }
    
        public override int GetHashCode(IEnumerable<T> obj)
        {
            return obj.Sum(p => p.GetHashCode() + p.GetHashCode());
        }
    }
    
