    public partial class Service1Client
    {
        static bool _isOpen;
        static DateTime _cachedResponse;
        object _locker = new object();
        public DateTime GetResponseData()
        {
            if (!_isOpen)
            {
                _isOpen = true;
                Task.Factory.StartNew<DateTime>(() =>
                {
                    lock (_locker)
                    {
                        _cachedResponse = GetData();
                        _isOpen = false;
                    }
                    return _cachedResponse;
                });
            }
            return _cachedResponse;
        }
    }
