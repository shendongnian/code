    public class TypeComparer<T> : IComparer<T>, IEqualityComparer<T> where T : class
    {
        public static readonly TypeComparer<T> Singleton= new TypeComparer<T>();
        private TypeComparer(){}
        bool IEqualityComparer<T>.Equals(T x, T y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x == null || y == null) return false;
            Type xType = x.GetType(), yType = y.GetType();
            return xType == yType && EqualityComparer<T>.Default.Equals(x, y);
        }
        int IEqualityComparer<T>.GetHashCode(T x)
        {
            if (x == null) return 0;
            return -17*x.GetType().GetHashCode() + x.GetHashCode();
        }
        int IComparer<T>.Compare(T x, T y)
        {
            if(x==null) return y == null ? 0 : -1;
            if (y == null) return 1;
    
            Type xType = x.GetType(), yType = y.GetType();
            int delta = xType == yType ? 0 : string.Compare(
                   xType.FullName, yType.FullName);
            if (delta == 0) delta = Comparer<T>.Default.Compare(x, y);
            return delta;
        }
    }
