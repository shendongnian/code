    public class C<T>
    {
        IEnumerable<T> _items;
        public C(IEnumerable<T> items)
        {
            _items = items;
        }
        public C<U> Convert<U>(Func<T, U> convertElement)
        {
            return new C<U>(_items.Select(convertElement));
        }
    }
