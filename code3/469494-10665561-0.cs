    namespace Timer10Sec
    {
        class Program
        {
            static void Main(string[] args)
            {
                Thread t = new Thread(new ThreadStart(After10Sec));
                t.Start();
            }
    
            public static void After10Sec()
            {
                Thread.Sleep(10000);
                while (true)
                {
                    Console.WriteLine("qwerty");
                }
            }
        }
    }
