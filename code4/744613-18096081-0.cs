        class Program
    {
        static void Main(string[] args)
        {
            Invoke(new ThreadStart(Do));
            Console.ReadLine();
        }
        public static void Do()
        {
            for (int i = 0; i < 10000000; i++)
            {
                Console.WriteLine("Test: " + i.ToString());
            }
        }
        public static void Invoke(ThreadStart ThreadStart)
        {
            Thread cCurrentThread = null;
            try
            {
                cCurrentThread = new Thread(ThreadStart);
                cCurrentThread.Start();
            }
            catch (Exception ex)
            {
            }
        }
    }
