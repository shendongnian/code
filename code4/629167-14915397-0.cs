    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<ManualResetEvent>();
            for (var i = 0; i < 10000; i++)
            {
                var m = new ManualResetEvent(false);
                list.Add(m);
                new Thread(Start).Start(m);
                if (i > 0 && (i % 10) == 0)
                    for (int j = i - 10; j < i; j++)
                    {
                        list[j].WaitOne(1000);// wait signal
                        GC.Collect(); //force finalizer
                        A.Print();
                }
            }
        }
        private static void Start(object obj)
        {
            new A(obj as ManualResetEvent);
        }
    }
    public class A : IThirdPartyInterface
    {
        public static long time1;
        public static long count1;
        private DateTime start = DateTime.Now;
        private ManualResetEvent _stop;
        private IThirdPartyInterface _origin;
        public A(ManualResetEvent stop, IThirdPartyInterface origin)
        {
            _stop = stop;
            _origin = origin;
        }
        
        ~A()
        {
            Interlocked.Increment(ref count1);
            Interlocked.Add(ref time1, (long)(DateTime.Now - start).TotalMilliseconds);
            _stop.Set(); //send signal
        }
        public static void Print()
        {
            Console.Write("\r" + A.time1 + "\\" + A.count1 + "    ");
            if (A.count1 != 0)
                Console.Write((A.time1 / A.count1).ToString());
        }
    }
