    public class InMemoryRepository<T> : IRepository<T> where T : class
    {
        protected readonly List<T> _list = new List<T>();
        public virtual IQueryable<T> GetAll()
        {
            return _list.AsReadOnly().AsQueryable();
        }
        public virtual T Get(object id)
        {
            return _list.FirstOrDefault(x => GetId(x).Equals(id));
        }
        public virtual void Save(T item)
        {
            if (_list.Any(x => EqualsById(x, item)))
            {
                Delete(item);
            }
            _list.Add(item);
        }
        public virtual void Delete(T item)
        {
            var itemInRepo = _list.FirstOrDefault(x => EqualsById(x, item));
            if (itemInRepo != null)
            {
                _list.Remove(itemInRepo);
            }
        }
    }
