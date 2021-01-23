    public class ObjectIdentityEqualityComparer : IEqualityComparer<object>
    {
        public int GetHashCode(object o)
        {
            return o.GetHashCode();
        }
    
        bool IEqualityComparer<object>.Equals(object o1, object o2)
        {
            return object.ReferenceEquals(o1, o2);
        }
    }
