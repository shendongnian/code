        private static event EventHandler<EventArgs> test;
        static void Main()
        {
            var e = new ParallelEvent<EventArgs>(Test1, Test2);
            test += e.Handler;
            test(null, EventArgs.Empty);
        }
        static void Test1(Object sender, EventArgs args)
        {
            Console.WriteLine("Start Test 1");
            Thread.Sleep(100);
            Console.WriteLine("End Test 1");
        }
        static void Test2(Object sender, EventArgs args)
        {
            Console.WriteLine("Start Test 2");
            Thread.Sleep(100);
            Console.WriteLine("End Test 2");
        }
