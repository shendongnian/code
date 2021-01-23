        private const int MaxWaitTime = 5000;
        private SqlListener<RecordType> _recordListener;
        private RecordType _record;
        private readonly ManualResetEvent _recordWaiter = new ManualResetEvent(false);
        /// <summary>
        /// Request a record and wait until it is found.
        /// </summary>
        public RecordType GetRecordAwait(int requestedId)
        {
            // Initiate listening for record
            _recordListener = new SqlListener<RecordType>();
            _recordListener.SqlModified += SqlListener_SqlModified;
            _recordListener.StartListening(requestedId);
            // Wait synchronously until record is found
            _recordWaiter.WaitOne(MaxWaitTime);
            // Stop listening
            _recordListener.SqlModified -= SqlListener_SqlModified;
            _recordListener.Dispose();
            _recordListener = null;
            // Return record
            return _record;
        }
        private void SqlListener_SqlModified(object sender, SqlModifiedArgs args)
        {
            _record = (RecordType)args.Record;
            _recordWaiter.Set();
        }
