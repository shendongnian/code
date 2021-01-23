        [STAThread]
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "MAIN THREAD";
            Console.WriteLine("Method Main: " + Thread.CurrentThread.Name);
            EventLoop.Run(MainProc, args);
        }
        static void MainProc(string[] args)
        {
            Console.WriteLine("Method MainProc: " + Thread.CurrentThread.Name);
            Console.WriteLine("Queuing Long Running Task...");
            EventLoop.EnqueueAsyncTask(new Func<int,int,int>(LongCalculation), new object[]{5,6}, new Action<int>(PrintResult));
            Console.WriteLine("Queued Long Running Task");
            
            Thread.Sleep(400); //Do more work
            EventLoop.EnqueueAsyncTask(new Func<int, int, int>(LongCalculation), new object[] { 15, 16 }, new Action<int>(PrintResult));
            Thread.Sleep(150); //Do some more work but within this time 2nd task is not able to complete, meanwhile 1st task completes
            
            //Long running Tasks will run in background but callback will be executed only when Main thread becomes idle
            //To execute the callbacks before that, call Application.DoEvents
            Application.DoEvents(); //PrintResult for 1st task as 2nd is not yet complete
            Console.WriteLine("Method MainProc: Working over-time!!!!");
            Thread.Sleep(500); //After this sleep, 2nd Task's print will also be called as Main thread will become idle
        }
        static int LongCalculation(int a, int b)
        {
            Console.WriteLine("Method LongCalculation, Is Thread Pool Thread: " + Thread.CurrentThread.IsThreadPoolThread);
            Console.WriteLine("Running Long Calculation");
            Thread.Sleep(500); //long calc
            Console.WriteLine("completed Long Calculation");
            return a + b;
        }
        static void PrintResult(int a)
        {
            Console.WriteLine("Method PrintResult: " + Thread.CurrentThread.Name);
            Console.WriteLine("Result: " + a);
            //Continue processing potentially queuing more long running tasks
        }
