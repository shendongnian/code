    public class Search<T> where T : class
    {
        private List<T> _list;
        public Search()
        {
            _list = new List<T>();
        }
        public int Find(Func<T, bool> whereClause)
        {
            return _list.IndexOf(_list.Where<T>(whereClause).FirstOrDefault<T>());
        }
    }
