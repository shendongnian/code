        public static void Main(String[] args)
        {
            var t = new Thread(LoopForever);
            t.Start();
            Thread.Sleep(500);
            Console.WriteLine("request sent, please wait..");
            t.Abort();
            t.Join();
            Console.WriteLine("done!");
            Console.ReadLine();
        }
        public static void LoopForever()
        {
            Console.WriteLine("Running!");
            while (true)
            {
                Thread.Sleep(100);
                Console.WriteLine("Running!");
            }
        }
