        public static void Main(String[] args)
        {
            var t = new Thread(LoopForever);
            t.Start();
            // Let the thread get started...
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
                    try
                    {
                        Console.WriteLine("Running!");
                        Thread.Sleep(100);
                    }
                    catch (ThreadAbortException ex)
                    {
                        Console.WriteLine("Alas, I was aborted!");
                        Thread.ResetAbort();
                        Console.WriteLine("But behold, I live!");
                    }
                }
        }
