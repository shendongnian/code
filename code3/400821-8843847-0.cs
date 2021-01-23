    public sealed class ReferenceEqualityComparer<T> : IEqualityComparer<T>
    {
        bool IEqualityComparer<T>.Equals(T x, T y)
        {
            return Object.ReferenceEquals(x, y);
        }
        int IEqualityComparer<T>.GetHashCode(T obj)
        {
            return System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(obj);
        }
    }
