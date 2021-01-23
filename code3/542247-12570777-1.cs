    using System.Threading;
    public class MyThread
    {
        public void ThreadFunc()
        {
            // do nothing apart from sleep a bit
            System.Console.WriteLine("In Timer Function!");
            Thread.Sleep(new TimeSpan(0, 0, 5));
        }
    };
    class Program
    {
        static void Main(string[] args)
        {
            bool bExit = false;
            DateTime tmeLastExecuted;
            // while we don't have a condition to exit the thread loop
            while (!bExit)
            {
                // create a new instance of our thread class and ThreadStart paramter
                MyThread myThreadClass = new MyThread();
                Thread newThread = new Thread(new ThreadStart(myThreadClass.ThreadFunc));
                
                // just as well join the thread until it exits
                tmeLastExecuted = DateTime.Now; // update timing flag
                newThread.Start();
                newThread.Join();
                // when we are in the timing threshold to execute a new thread, we can exit
                // this loop
                System.Console.WriteLine("Sleeping for a bit!");
                // only allowed to execute a thread every 10 seconds minimum
                while (DateTime.Now - tmeLastExecuted < new TimeSpan(0, 0, 10));
                {
                    Thread.Sleep(100); // sleep to make sure program has no tight loops
                }
                System.Console.WriteLine("Ok, going in for another thread creation!");
            }
        }
    }
