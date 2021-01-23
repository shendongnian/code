    public partial class Service1Client
    {
        // default time buffer value
        int _timeBuffer = 100;
        // a time buffer used for returning the same response  
        public int TimeBuffer
        {
            get { return _timeBuffer; }
            set { _timeBuffer = value; }
        }
        // the start and end time of the web service request
        static DateTime _start, _end;
        // a volatile static variable to store the response in the buffering time
        volatile static string _response;
        // used for blocking other threads until the current thread finishes it's job
        object _locker = new object();
        public async Task<string> GetResponseData()
        {
            return await Task.Factory.StartNew<string>(() =>
            {
                lock (_locker)
                {
                    if (DateTime.Now >= _end.AddMilliseconds(TimeBuffer))
                    {
                        _start = DateTime.Now;
                        var async = GetDataAsync();
                        _response = async.Result;
                        _end = DateTime.Now;
                    }
                }
                return _response;
            });
        }
    }
