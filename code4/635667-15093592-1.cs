    class Program
    {
        static void Main(string[] args)
        {
            ThreadDispatcher td=new ThreadDispatcher();
            Runner r1 = td.CreateHpThread(d=>OnHpThreadRun(d,1));
            Runner r2 = td.CreateHpThread(d => OnHpThreadRun(d, 2));
            Runner l1 = td.CreateLpThread(d => Console.WriteLine("Running low priority thread 1"));
            Runner l2 = td.CreateLpThread(d => Console.WriteLine("Running low priority thread 2"));
            Runner l3 = td.CreateLpThread(d => Console.WriteLine("Running low priority thread 3"));
            l1.Start();
            l2.Start();
            l3.Start();
            r1.Start();
            r2.Start();
            Console.ReadLine();
            l1.Stop();
            l2.Stop();
            l3.Stop();
            r1.Stop();
            r2.Stop();
        }
        private static void OnHpThreadRun(ThreadDispatcher d,int number)
        {
            Random r=new Random();
            Thread.Sleep(r.Next(100,2000));
            d.CheckedIn();
            Console.WriteLine(string.Format("*** Starting High Priority Thread {0} ***",number));
            Thread.Sleep(r.Next(100, 2000));
            Console.WriteLine(string.Format("+++ Finishing High Priority Thread {0} +++", number));
            Thread.Sleep(300);
            d.CheckedOut();           
        }
    }
    public abstract class Runner
    {
        private Thread _thread;
        protected readonly Action<ThreadDispatcher> _action;
        private readonly ThreadDispatcher _dispathcer;
        private long _running;
        readonly ManualResetEvent _stopEvent=new ManualResetEvent(false);
        protected Runner(Action<ThreadDispatcher> action,ThreadDispatcher dispathcer)
        {
            _action = action;
            _dispathcer = dispathcer;
        }
        public void Start()
        {
            _thread = new Thread(OnThreadStart);
            _running = 1;
            _thread.Start();
        }
        public void Stop()
        {
            _stopEvent.Reset();
            Interlocked.Exchange(ref _running, 0);
            _stopEvent.WaitOne(2000);
            _thread = null;
            Console.WriteLine("The thread has been stopped.");
        }
        protected virtual void OnThreadStart()
        {
            while (Interlocked.Read(ref _running)!=0)
            {
                OnStartWork();
                _action.Invoke(_dispathcer);
                OnFinishWork();
            }
            OnFinishWork();
            _stopEvent.Set();
        }
        protected abstract void OnStartWork();
        protected abstract void OnFinishWork();
    }
    public class ThreadDispatcher
    {
        private readonly ManualResetEvent _signal=new ManualResetEvent(true);
        private int _hpCheckedInThreads;
        private readonly object _lockObject = new object();
        public void CheckedIn()
        {
            lock(_lockObject)
            {
                _hpCheckedInThreads++;
                _signal.Reset();
            }
        }
        public void CheckedOut()
        {
            lock(_lockObject)
            {
                if(_hpCheckedInThreads>0)
                    _hpCheckedInThreads--;
                if (_hpCheckedInThreads == 0)
                    _signal.Set();
            }
        }
        private class HighPriorityThread:Runner 
        {
            public HighPriorityThread(Action<ThreadDispatcher> action, ThreadDispatcher dispatcher) : base(action,dispatcher)
            {
            }
            protected override void OnStartWork()
            {
            }
            protected override void OnFinishWork()
            {
            }
        }
        private class LowPriorityRunner:Runner
        {
            private readonly ThreadDispatcher _dispatcher;
            public LowPriorityRunner(Action<ThreadDispatcher> action, ThreadDispatcher dispatcher)
                : base(action, dispatcher)
            {
                _dispatcher = dispatcher;
            }
            protected override void OnStartWork()
            {
                Console.WriteLine("LP Thread is waiting for a signal.");
                _dispatcher._signal.WaitOne();
                Console.WriteLine("LP Thread got the signal.");
            }
            protected override void OnFinishWork()
            {
                
            }
        }
        public Runner CreateLpThread(Action<ThreadDispatcher> action)
        {
            return new LowPriorityRunner(action, this);
        }
        public Runner CreateHpThread(Action<ThreadDispatcher> action)
        {
            return new HighPriorityThread(action, this);
        }
    }
}
