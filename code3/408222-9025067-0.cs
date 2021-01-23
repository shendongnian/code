    public class BaseEntity<T> where T : BaseEntity<T>
    {
        public long Id { get; set; }
        public class Comparer : IEqualityComparer<T>
        {
            public bool Equals(T x, T y)
            {
                if (x.Id == y.Id)
                {
                    return true;
                }
                return false;
            }
            public int GetHashCode(T obj)
            {
                return (int)obj.Id;
            }
        }
    }
