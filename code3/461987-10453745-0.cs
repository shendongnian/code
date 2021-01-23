    class Program
    {
        public static void Main(string[] args)
        {
            string locker = "str", temp = "temp";
            string locker1 = locker + temp;
            string locker2 = locker + temp;
            Console.WriteLine("HashCode{0} {1}", locker1.GetHashCode(), locker2.GetHashCode());
            Console.WriteLine("Equals {0}", locker1.Equals(locker2));
            Console.WriteLine("== {0}", locker1 == locker2);
            Console.WriteLine("ReferenceEquals {0}", ReferenceEquals(locker1, locker2));
            app.Program p = new Program();
            Action<string> threadCall = p.Run;
            threadCall.BeginInvoke(locker1, null, null);
            threadCall.BeginInvoke(locker2, null, null);
            Console.Read();
        }
        public void Run(string str)
        {
            lock (str)
            {
                Console.WriteLine("im in");
                Thread.Sleep(4000);
                Console.WriteLine("print from thread id {0}", Thread.CurrentThread.ManagedThreadId);
            }
        }
    }
