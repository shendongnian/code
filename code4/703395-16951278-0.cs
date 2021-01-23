    public class Program
    {
        private static EventWaitHandle _waitHandle;
        private const int ThreadCount = 20;
        private static int _signalledCount = 0;
        private static int _invokedCount = 0;
        private static int _eventCapturedCount = 0;
        private static CountdownEvent _startCounter;
        private static CountdownEvent _invokeCounter;
        private static CountdownEvent _eventCaptured;
        
        public static void Main(string[] args)
        {
            _waitHandle = new EventWaitHandle(false, EventResetMode.ManualReset);
            _startCounter = new CountdownEvent(ThreadCount);
            _invokeCounter = new CountdownEvent(ThreadCount);
            _eventCaptured = new CountdownEvent(ThreadCount);
            
            //Start multiple threads that block until signalled
            for (int i = 1; i <= ThreadCount; i++)
            {
                var t = new Thread(new ParameterizedThreadStart(ThreadProc));
                t.Start(i);
            }
            //Allow all threads to start
            Thread.Sleep(100);
            _startCounter.Wait();
            Console.WriteLine("Press ENTER to allow waiting threads to proceed.");
            Console.ReadLine();
            //Signal threads to start
            _waitHandle.Set();
            //Wait for all threads to acknowledge start
            _invokeCounter.Wait();
            //Signal threads to proceed
            _waitHandle.Reset();
            Console.WriteLine("All threads ready. Raising event.");
            var me = new object();
            //Raise the event
            MyEvent(me, new EventArgs());
            //Wait for all threads to capture event
            _eventCaptured.Wait();
            Console.WriteLine("{0} of {1} threads responded to event.", _eventCapturedCount, ThreadCount);
            Console.ReadLine();
        }
        public static EventHandler MyEvent;
        public static void ThreadProc(object index)
        {
            //Signal main thread that this thread has started
            _startCounter.Signal();
            Interlocked.Increment(ref _signalledCount);
            //Subscribe to event
            MyEvent += delegate(object sender, EventArgs args) 
            { 
                Console.WriteLine("Thread {0} responded to event.", index);
                _eventCaptured.Signal();
                Interlocked.Increment(ref _eventCapturedCount);
            };
            Console.WriteLine("Thread {0} blocks.", index);
            //Wait for main thread to signal ok to start
            _waitHandle.WaitOne();
            //Signal main thread that this thread has been invoked
            _invokeCounter.Signal();
            Interlocked.Increment(ref _invokedCount);
        }
    }
