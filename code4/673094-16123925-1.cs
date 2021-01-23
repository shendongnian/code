    /// <summary>
    /// A non-persistent repository implementation for mocking the repository layer.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ListRepository<T> : RepositoryBase<T>
        where T : class
    {
        private readonly List<T> _items = new List<T>();
        public ListRepository(IEnumerable<T> items, Expression<Func<T, T, bool>> keyCompare)
            : base(keyCompare)
        {
            _items.AddRange(items);
        }
        public override IQueryable<T> Select()
        { 
            return _items.AsQueryable(); 
        }
        public override void Save(T item)
        {
            var existing = Item(item);
            if (existing != null)
            {
                _items.Remove(item);
            }
            _items.Add(item);
        }
        public override void Save(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Save(item);
            }
        }
        public override void Delete(T item)
        {
            _items.Remove(item);
        }
        public override void Delete(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Delete(Item(item));
            }
        }
        /// <summary>
        /// Not implemented.
        /// </summary>
        /// <param name="existing"></param>
        /// <param name="item"></param>
        protected override void UpdateExisting(T existing, T item)
        {
            throw new NotImplementedException(); // list repo just wipes existing data
        }
    }
