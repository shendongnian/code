    public void Start()
    {
        _threads.Clear();
        _workers.Clear();
        var evts = new List<ManualResetEvent>()
        for (int i = 0; i < _options.NumberOfClients; i++)
        {
            ManualResetEvent evt = new ManualResetEvent(false);
            evts.Add(evt);
            _workers.Add(new Worker(evt));
            _threads.Add(new Thread(_workers.Last().PumpMessages));
            _threads.Last().Start();
        }
        WaitHandle.WaitAll(evts.ToArray());
    }
    public class Worker
    {
        private bool _shouldStop = false;
        private readonly ManualResetEvent @event;
        public Worker(ManualResetEvent @event)
        {
            this.@event = @event;
        }
        public void PumpMessages()
        {
            while (!_shouldStop)
            {
                //does cool stuff until told to stop
            }
            @event.Set();
        }
        public void RequestStop()
        {
            _shouldStop = true;
        }
    }
