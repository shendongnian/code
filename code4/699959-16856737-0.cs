            static void Producer()
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("Produced " + num++);
                    e.Set();
                }
            }
            static void Consumer()
            {
                while (true)
                {
                    e.WaitOne();
                    Console.WriteLine("Consumed " + num);
                }
            }
