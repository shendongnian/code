        // This will increment the count and kick off the process of going through
        // the calls if it isn't already running. When it is done, it nulls out the task again
        // to be recreated when something is queued again.
        public static void QueueSomething()
        {
            doSomethingCount++;
            if (doSomethingTask == null)
            {
                doSomethingTask =
                    Task.Run((Action)(() =>
                    {
                        while (doSomethingCount > 0)
                        {
                            DoSomething();
                            doSomethingCount--;
                        }
                    }))
                    .ContinueWith(t => doSomethingTask = null);
            }
        }
        // I just put something in here that would take time and have a measurable result.
        private static void DoSomething()
        {
            Thread.Sleep(50);
            thingsDone++;
        }
        // These two guys are the data members needed.
        private static int doSomethingCount = 0;
        private static Task doSomethingTask;
        // This code is just to prove that it works the way I expected. You can use it too.
        public static void Run()
        {
            for (int i = 0; i < 10; i++)
            {
                QueueSomething();
            }
            while (thingsDone < 10)
            {
                Thread.Sleep(100);
            }
            thingsDone = 0;
            QueueSomething();
            while (thingsDone < 1)
            {
                Thread.Sleep(100);
            }
            Console.WriteLine("Done");
        }
        // This data point is just so I could test it. Leaving it in so you can prove it yourself.
        private static int thingsDone = 0;
