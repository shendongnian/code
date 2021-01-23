    public class PosList<T> : List<T>, ICollection<T>, IList
    {
        public ValuesList(IEnumerable<T> items) : base(items) { }
        bool ICollection<T>.IsReadOnly { get { return true; } }
        bool IList.IsReadOnly { get { return true; } }
    }
