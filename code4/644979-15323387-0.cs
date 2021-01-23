    interface IIndexer
    {
        object this[string index] { get; }
    }
    class DataReaderWrapper : IIndexer
    {
        private readonly IDataReader _reader;
        public DataReaderWrapper(IDataReader reader)
        {
            _reader = reader;
        }
        public object this[string index]
        {
            get { return _reader[index]; }
        }
    }
    class DataRowWrapper : IIndexer
    {
        private readonly DataRow _row;
        public DataRowWrapper(DataRow row)
        {
            _row = row;
        }
        public object this[string index]
        {
            get { return _row[index]; }
        }
    }
