    class A
    {
        private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
        string path = "file.xml";
        static public object _lock = new object();
        static private int accessCounter = 0;
        public List<T> GetItems()
        {
            _lock.EnterReadLock();
            try
            {
                using (Stream stream = File.OpenRead(path))
                {
                    var serializer = new XmlSerializer(typeof(List<T>), new[] { typeof(T) });
                    return (List<T>)serializer.Deserialize(stream);
                }
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }
        public void AddItem(T item)
        {
            _lock.EnterWriteLock();
            try
            {
                // Some writing operations
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }
    }
