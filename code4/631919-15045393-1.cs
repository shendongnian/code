    public static class Program
    {
        private static int _counter0 = 0;
        private static int _counterA = 0;
        private static int _counterB = 0;
        private static int _counterAb = 0;
        private static void SendMessage(Message m)
        {
            if (m != null)
                if (m.a != null)
                    if (m.b != null)
                        Interlocked.Increment(ref _counterAb);
                    else
                        Interlocked.Increment(ref _counterA);
                else if (m.b != null)
                    Interlocked.Increment(ref _counterB);
                else
                    Interlocked.Increment(ref _counter0);
        }
        static Thread[] Start(int threadCount, int eventCount,
            int eventInterval, int wrapTimeout, Func<int, int, Tuple<Message, bool>> wrap)
        {
            Thread[] threads = new Thread[threadCount];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(
                    () =>
                        {
                            for (int j = 0; j < eventCount; j++)
                            {
                                var result = wrap(j, wrapTimeout);
                                if (result.Item2)
                                {
                                    SendMessage(result.Item1);
                                }
                                Thread.Sleep(eventInterval);
                            }
                            Thread.Sleep(eventInterval);
                        });
                threads[i].Start();
            }
            return threads;
        }
        static void Join(params Thread[] threads)
        {
            foreach (Thread thread in threads)
            {
                thread.Join();
            }
        }
        public static void Main(string[] args)
        {
            var wrapper = new MessageWrapper();
            var sw = Stopwatch.StartNew();
            // Only A events
            var t0 = Start(10, 40, 7, 1000, wrapper.WrapA);
            Join(t0);
            // A and B events
            var t1 = Start(10, 40, 7, 1000, wrapper.WrapA);
            var t2 = Start(10, 10, 19, 1000, wrapper.WrapB);
            Join(t1);
            Join(t2);
            // Only B events
            var t3 = Start(10, 20, 7, 1000, wrapper.WrapB);
            Join(t3);
            Console.WriteLine(sw.Elapsed);
            Console.WriteLine("0:  {0}", _counter0);
            Console.WriteLine("A:  {0}", _counterA);
            Console.WriteLine("B:  {0}", _counterB);
            Console.WriteLine("AB: {0}", _counterAb);
            Console.WriteLine("Sent A: {0}, Received A: {1}",
                10 * 40 + 10 * 40, _counterA + _counterAb);
            Console.WriteLine("Sent B: {0}, Received B: {1}",
                10 * 10 + 10 * 20, _counterB + _counterAb);
            Console.WriteLine("Total: " + (_counter0 + _counterA + _counterB + _counterAb*2));
        }
    }
    public class MessageWrapper
    {
        readonly object _gate = new object();
        int? _pendingB;
        public Tuple<Message, bool> WrapA(int a, int millisecondsTimeout)
        {
            int? currentB;
            lock (_gate)
            {
                currentB = _pendingB;
                _pendingB = null;
                Monitor.Pulse(_gate); // B stolen, get rid of waiting threads
            }
            return Tuple.Create(new Message(a, currentB), true);
        }
        public Tuple<Message, bool> WrapB(int b, int millisecondsTimeout)
        {
            lock (_gate)
            {
                if (_pendingB != null)
                {
                    var currentB = _pendingB;
                    _pendingB = b;
                    Monitor.Pulse(_gate); // release for fairness
                    Monitor.Wait(_gate, millisecondsTimeout); // wait for fairness
                    return Tuple.Create(new Message(null, currentB), true);
                }
                else
                {
                    _pendingB = b;
                    Monitor.Pulse(_gate); // release for fairness
                    Monitor.Wait(_gate, millisecondsTimeout); // wait for A
                    var currentB = _pendingB;
                    if (currentB != null)
                    {
                        _pendingB = null;
                        return Tuple.Create(new Message(null, currentB), true);
                    }
                    return Tuple.Create<Message, bool>(null, false);
                }
            }
        }
    }
    public class Message
    {
        public readonly int? a;
        public readonly int? b;
        public Message(int? a, int? b)
        {
            this.a = a;
            this.b = b;
        }
    }
