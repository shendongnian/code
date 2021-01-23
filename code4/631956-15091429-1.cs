    public static class Program
    {
        private static int _counter0 = 0;
        private static int _counterA = 0;
        private static int _counterB = 0;
        private static int _counterAb = 0;
        private static object _lastA;
        private static object _lastB;
        private static object _firstA;
        private static object _firstB;
        public static void Main(string[] args)
        {
            var wrapper = new MessageWrapper();
            var sw = Stopwatch.StartNew();
            var threadsCount = 10;
            var a0called = 40;
            // Only A events
            var t0 = Start(threadsCount, a0called, 7, 1000, wrapper.SendA);
            Join(t0);
            var aJointCalled = 40;
            var bJointCalled = 10;
            var syncEvent = new CountdownEvent(threadsCount + threadsCount);
            _firstA = null;
            _firstB = null;
            // A and B events
            var t1 = Start(threadsCount, aJointCalled, 7, 1000, wrapper.SendA, syncEvent);
            var t2 = Start(threadsCount, bJointCalled, 19, 1000, wrapper.SendB, syncEvent);
            Join(t1);
            Join(t2);
            var lastA = _lastA;
            var lastB = _lastB;
            var b0called = 20;
            // Only B events
            var t3 = Start(threadsCount, b0called, 7, 1000, wrapper.SendB);
            Join(t3);
            Console.WriteLine(sw.Elapsed);
            Console.WriteLine("0:  {0}", _counter0);
            Console.WriteLine("A:  {0}", _counterA);
            Console.WriteLine("B:  {0}", _counterB);
            Console.WriteLine("AB: {0}", _counterAb);
            Console.WriteLine(
                "Generated A: {0}, Sent A: {1}",
                (threadsCount * a0called) + (threadsCount * aJointCalled),
                _counterA + _counterAb);
            Console.WriteLine(
                "Generated B: {0}, Sent B: {1}",
                (threadsCount * bJointCalled) + (threadsCount * b0called),
                _counterB + _counterAb);
            Console.WriteLine("First A was sent on {0: MM:hh:ss ffff}", _firstA);
            Console.WriteLine("Last A was sent on {0: MM:hh:ss ffff}", lastA);
            Console.WriteLine("First B was sent on {0: MM:hh:ss ffff}", _firstB);
            Console.WriteLine("Last B was sent on {0: MM:hh:ss ffff}", lastB);
            Console.ReadLine();
        }
        private static void SendMessage(Message m)
        {
            if (m != null)
            {
                if (m.A != null)
                {
                    if (m.B != null)
                    {
                        Interlocked.Increment(ref _counterAb);
                    }
                    else
                    {
                        Interlocked.Increment(ref _counterA);
                        Interlocked.Exchange(ref _lastA, DateTime.Now);
                        Interlocked.CompareExchange(ref _firstA, DateTime.Now, null);
                    }
                }
                else if (m.B != null)
                {
                    Interlocked.Increment(ref _counterB);
                    Interlocked.Exchange(ref _lastB, DateTime.Now);
                    Interlocked.CompareExchange(ref _firstB, DateTime.Now, null);
                }
                else
                {
                    Interlocked.Increment(ref _counter0);
                }
            }
        }
        private static Thread[] Start(
            int threadCount, 
            int eventCount, 
            int eventInterval, 
            int wrapTimeout, 
            Action<int, int, Action<Message>> wrap,
            CountdownEvent syncEvent = null)
        {
            var threads = new Thread[threadCount];
            for (int i = 0; i < threadCount; i++)
            {
                threads[i] = new Thread(
                    (p) =>
                        {
                            if (syncEvent != null)
                            {
                                syncEvent.Signal();
                                syncEvent.Wait();
                            }
                            Thread.Sleep((int)p);
                            for (int j = 0; j < eventCount; j++)
                            {
                                int k = (((int)p) * 1000) + j;
                                Thread.Sleep(eventInterval);
                                wrap(k, wrapTimeout, SendMessage);
                            }
                        });
                threads[i].Start(i);
            }
            return threads;
        }
        private static void Join(params Thread[] threads)
        {
            foreach (Thread t in threads)
            {
                t.Join();
            }
        }
    }
