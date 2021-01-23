    public class MyList<T> : IMyList<T>
    {
        private readonly List<T> _list = new List<T>();
        #region Implementation of IMyList<in T>
        public void Add(T item)
        {
            Console.WriteLine("Adding an item: {0}", item);
            _list.Add(item);
        }
        public void AddRange(IEnumerable<T> itemList)
        {
            Console.WriteLine("Adding items!");
            _list.AddRange(itemList);
        }
        #endregion
        #region Implementation of IEnumerable
        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
