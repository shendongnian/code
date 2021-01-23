        static void Main(string[] args)
        {
            ManualResetEvent flag = new ManualResetEvent(false);
            object workResult = null;
            Task[] myTasks = new Task[10];
            for (int ix = 0; ix < myTasks.Length; ++ix)
            {
                myTasks[ix] = Task.Factory.StartNew(() =>
                {
                    flag.WaitOne();
                    Console.WriteLine("Work Item Executed: {0}", workResult);
                });
            }
            
            Thread.Sleep(1000);
            workResult = "asdf";
            flag.Set();
            Task.WaitAll(); // Eliminates race condition
            flag.Close();
            Console.WriteLine("Finished");
        }
