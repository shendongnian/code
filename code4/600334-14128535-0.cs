    internal class Program
    {
        private static void Main(string[] args)
        {
            ReactiveTest rx1 = null;
            ReactiveTest rx2 = null;
            var thread1 = new Thread(() => rx1 = new ReactiveTest());
            var thread2 = new Thread(() => rx2 = new ReactiveTest());
            thread1.Start();
            thread2.Start();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            thread1.Join();
            thread2.Join();
            rx1.Dispose();
            rx2.Dispose();
        }
    }
    public class ReactiveTest : IDisposable
    {
        private IDisposable _timerObservable;
        private object _lock = new object();
        public ReactiveTest()
        {
            _timerObservable = Observable.Interval(TimeSpan.FromMilliseconds(250)).Subscribe(i => 
                Console.WriteLine("[{0}] - {1}", Thread.CurrentThread.ManagedThreadId, i));
        }
        public void Dispose()
        {
            lock (_lock)
            {
                _timerObservable.Dispose();
                Console.WriteLine("[{0}] - DISPOSING", Thread.CurrentThread.ManagedThreadId);
            }
        }
    }
