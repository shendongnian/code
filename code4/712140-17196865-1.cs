    public class PropertyEqualityComparer<TObject, TProperty> 
        : IEqualityComparer<TObject>
    {
        Func<TObject, TProperty> _selector;
        IEqualityComparer<TProperty> _internalComparer;
        public PropertyEqualityComparer(Func<TObject, TProperty> propertySelector,
            IEqualityComparer<TProperty> innerEqualityComparer = null)
        {
            _selector = propertySelector;
            _internalComparer = innerEqualityComparer;
        }
        public int GetHashCode(TObject obj)
        {
            return _selector(obj).GetHashCode();
        }
        public bool Equals(TObject x, TObject y)
        {
            IEqualityComparer<TProperty> comparer = 
                _internalComparer ?? EqualityComparer<TProperty>.Default;
            return comparer.Equals(_selector(x), _selector(y));
        }
    }
