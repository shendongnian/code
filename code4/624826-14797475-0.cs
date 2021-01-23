    public class ZeroMqSubscriber
    {
        private readonly ZmqContext _zmqContext;
        private readonly ZmqSocket _zmqSocket;
        private readonly Thread _workerThread;
        private readonly ManualResetEvent _stopEvent = new ManualResetEvent(false);
        private readonly object _locker = new object();
        private readonly Queue<string> _queue = new Queue<string>();
        public ZeroMqSubscriber(string endPoint)
        {
            _zmqContext = ZmqContext.Create();
            _zmqSocket = _zmqContext.CreateSocket(SocketType.SUB);
            _zmqSocket.Connect(endPoint);
            _zmqSocket.SubscribeAll();
            _workerThread = new Thread(ReceiveData);
            _workerThread.Start();
        }
        public string[] GetMessages()
        {
            lock (_locker)
            {
                var messages = _queue.ToArray();
                _queue.Clear();
                return messages;
            }
        }
        public void Stop()
        {
            _stopEvent.Set();
            _workerThread.Join();
        }
        private void ReceiveData()
        {
             try
             {
                 while (!_stopEvent.WaitOne(0))
                 {
                     var message = _zmqSocket.Receive(Encoding.UTF8, new TimeSpan(0, 0, 0, 1));
                     if (string.IsNullOrEmpty(message))
                         continue;
                     lock (_locker)
                         _queue.Enqueue(message);
                 }
             }
             finally
             {
                 _zmqSocket.Dispose();
                 _zmqContext.Dispose();
             }
        }
    }
