    public class InMemoryDbSet<T> : IDbSet<T> where T : class
    {      
        private readonly HashSet<T> _data;
        private readonly IQueryable _query;
        public Type ElementType
        {
            get
            {
                return this._query.ElementType;
            }
        }
        public Expression Expression
        {
            get
            {
                return this._query.Expression;
            }
        }
        public IQueryProvider Provider
        {
            get
            {
                return this._query.Provider;
            }
        }
     
        public InMemoryDbSet()
        {
            this._data = new HashSet<T>();
            this._query = _data.AsQueryable();
        }
        public T Add(T entity)
        {
            this._data.Add(entity);
            return entity;
        }
        public T Attach(T entity)
        {
            this._data.Add(entity);
            return entity;
        }
        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
        {
            throw new NotImplementedException();
        }
        public T Create()
        {
            return Activator.CreateInstance<T>();
        }
        public virtual T Find(params Object[] keyValues)
        {
            throw new NotImplementedException("Derive from FakeDbSet and override Find");
        }
        public System.Collections.ObjectModel.ObservableCollection<T> Local
        {
            get
            {
                return new System.Collections.ObjectModel.ObservableCollection<T>(_data);
            }
        }
        public T Remove(T entity)
        {
            this._data.Remove(entity);
            return entity;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return this._data.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._data.GetEnumerator();
        }
    }
