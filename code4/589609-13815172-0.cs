        private const int Total = 500000;
        private static volatile int _count = 0;
        private static void Main()
        {
            Task task = Task.Factory.StartNew(Decrement);
            for (int i = 0; i < Total; i++)
            {
                System.Threading.Interlocked.Increment(ref _count);
            }
            task.Wait();
            Console.WriteLine(_count);
            Console.ReadLine();
        }
        private static void Decrement()
        {
            for (int i = 0; i < Total; i++)
            {
                System.Threading.Interlocked.Decrement(ref _count);
            }
        }
