    public static class Counter
    {
        private static long _seriesProcessedItems = 0;
        private static long _totalProcessedItems = 0;
        private static TimeSpan _totalTime = TimeSpan.Zero;
        private static DateTime _operationStartTime;
        private static object _lock = new object();
        private static int _numberOfCurrentOperations = 0;
        public static void StartAsyncOperation()
        {
            lock (_lock)
            {
                if (_numberOfCurrentOperations == 0)
                {
                    _operationStartTime = DateTime.Now;   
                }
                _numberOfCurrentOperations++;
            }
        }
        public static void EndAsyncOperation(int itemsProcessed)
        {
            lock (_lock)
            {
                _numberOfCurrentOperations--;
                if (_numberOfCurrentOperations < 0) 
                    throw new InvalidOperationException("EndAsyncOperation without StartAsyncOperation");
                
                _seriesProcessedItems +=itemsProcessed;
                if (_numberOfCurrentOperations == 0)
                {
                    _totalProcessedItems += _seriesProcessedItems;
                    _totalTime += DateTime.Now - _operationStartTime;
                    _seriesProcessedItems = 0;
                }
            }
        }
        public static double GetAvgSpeed()
        {
            if (_totalProcessedItems == 0) throw new InvalidOperationException("_totalProcessedItems is zero");
            if (_totalProcessedItems == 0) throw new InvalidOperationException("_totalTime is zero");
            return _totalProcessedItems / (double)_totalTime.TotalMilliseconds;
        }
        public static void Reset()
        {
            _totalProcessedItems = 0;
            _totalTime = TimeSpan.Zero;
        }
    }
