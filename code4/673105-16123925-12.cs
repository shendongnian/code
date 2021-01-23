    public abstract class DataRepository<T> : RepositoryBase<T>
        where T : class
    {
        private DataContext _context;
        public DataRepository(DataContext context, Expression<Func<T, T, bool>> keyCompare)
            : base(keyCompare)
        {
            _context = context;
        }
        public override IQueryable<T> Select()
        {
            return _context.GetTable<T>().AsQueryable();
        }
        /// <summary>
        /// A method that updates an existing item or creates a new one, as needed.
        /// </summary>
        /// <param name="item">The entity containing the values to be saved.</param>
        public override void Save(T item)
        {
            var existing = Item(item);
            if (existing != null)
            {
                UpdateExisting(existing, item);
            }
            else
            {
                _context.GetTable<T>().InsertOnSubmit(item);
            }
            _context.SubmitChanges();
        }
        /// <summary>
        /// A method that deletes specified item.
        /// </summary>
        /// <param name="item"></param>
        public override void Delete(T item)
        {
            var existing = Item(item);
            if (existing != null)
            {
                _context.GetTable<T>().DeleteOnSubmit(existing);
            }
            _context.SubmitChanges();
        }
        public override void Delete(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Delete(item);
            }
        }
        protected override void UpdateExisting(T existing, T item)
        {
            throw new NotImplementedException(); // must override in derived classes - not obvious I know
        }
    }
