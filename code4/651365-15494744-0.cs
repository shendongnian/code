    class MyObject<T> : IEquatable<MyObject<T>>
    {
        private readonly IEqualityComparer<T> comparer;
        public MyObject(string otherProp, T value, IEqualityComparer<T> comparer)
        {
            this.comparer = comparer;
        }
        public MyObject(string otherProp, T value)
            : this(otherProp, value, EqualityComparer<T>.Default)
        {
        }
        
        public bool Equals(MyObject<T> other)
        {
            return OtherProp.Equals(other.OtherProp) && comparer.Equals(this.Value, other.Value);
        }
    }
