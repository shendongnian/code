    public class QueryableList<T> : System.Linq.IQueryable<T>
    {
        private IList<T> _data;
        public QueryableList()
        {
          _data = new List<T>();
        }
        public QueryableList(IList<T> data)
        {
          _data = data;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _data.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }
        public Expression Expression
        {
            get { return Expression.Constant(_data.AsQueryable()); }
        }
        public IQueryProvider Provider
        {
            get { return _data.AsQueryable().Provider; }
        }
        public Type ElementType
        {
            get { return typeof(T); }
        }
    }
