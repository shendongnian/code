    public class SQLDataAccessor<I, T> : IDataAccessorModel<I, T>
    {
        internal SQLDataAccessor(IResult<string> result)
        {
            _connectionString = "";
            _result = result;
        }
    
        private readonly string _connectionString;
        private IResult<string> _result;
    
        public T AccessType { get { return new SqlServer(); } }
        public I Instance { get; private set; }
    
        public IResult<string> Add(I instance)
        {
            Instance = instance;
            return _result;
        }
        public IResult<string> Get(I instance)
        {
            Instance = instance;
            return _result;
        }
        public IResult<string> Delete(I instance)
        {
            Instance = instance;
            return _result;
        }
        public IResult<string> Update(I instance)
        {
            Instance = instance;
            return _result;
        }
    }
