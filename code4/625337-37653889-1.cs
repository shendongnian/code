    public class EqualityComparerAdapter<T, V> : EqualityComparer<T>
        where V : IEquatable<V>
    {
        private Func<T, V> _valueAdapter;
    
        public EqualityComparerAdapter(Func<T, V> valueAdapter)
        {
            _valueAdapter = valueAdapter;
        }
    
        public override bool Equals(T x, T y)
        {
            return _valueAdapter(x).Equals(_valueAdapter(y));
        }
    
        public override int GetHashCode(T obj)
        {
            return _valueAdapter(obj).GetHashCode();
        }
    }
