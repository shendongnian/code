    public partial class Service1Client
    {
        static bool _isOpen;
        static DateTime? _cachedResponse;
        object _locker = new object();
        public DateTime GetResponseData()
        {
            if (!_isOpen)
            {
                if (!_cachedResponse.HasValue)
                {
                    lock (_locker)
                    {
                        _isOpen = true;
                        _cachedResponse = GetData();
                        _isOpen = false;
                    }
                    return _cachedResponse.Value;
                }
                else
                {
                    Task.Factory.StartNew<DateTime>(() =>
                    {
                        lock (_locker)
                        {
                            _isOpen = true;
                            _cachedResponse = GetData();
                            _isOpen = false;
                        }
                        return _cachedResponse.Value;
                    });
                }
            }
            return _cachedResponse.Value;
        }
    }
