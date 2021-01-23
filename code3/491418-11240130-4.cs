    public class IdentityComparer<T> : IEqualityComparer<T> where T : class
    {
        public bool Equals(T x, T y)
        {
            // Just for clarity...
            return object.ReferenceEquals(x, y);
        }
        public int GetHashCode(T x)
        {
            // The nullity check may be unnecessary due to a similar check in
            // RuntimeHelpers.GetHashCode, but it's not documented
            return x == null ? 0 : RuntimeHelpers.GetHashCode(x);
        }
    }
