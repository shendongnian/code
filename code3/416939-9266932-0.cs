    public interface IPhysicallyEquatable<T>
    {
        bool PhysicallyEquals(T other);
        int GetPhysicalHashCode();
    }
    public class PhysicalEqualityComparer<T> : IEqualityComparer<T>
        where T : IPhysicallyEquatable<T>
    {
        public bool Equals(T x, T y)
        {
            if (null == x) throw new ArgumentNullException("x");
            if (null == y) throw new ArgumentNullException("y");
            return x.PhysicallyEquals(y);
        }
        public int GetHashCode(T obj)
        {
            if (null == obj) throw new ArgumentNullException("obj");
            return obj.GetPhysicalHashCode();
        }
    }
    public interface IDevice : IPhysicallyEquatable<IDevice>
    {
        // ...
    }
