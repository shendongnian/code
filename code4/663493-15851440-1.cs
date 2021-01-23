    public class GenericComparer<T> : IEqualityComparer<T> where T : BaseClass
    {
        public bool Equals(T x, T y)
        {
            return x.Id == y.Id;
        }
    
        public int GetHashCode(T obj)
        {
            return obj.Id.GetHashCode();
        }
    }
