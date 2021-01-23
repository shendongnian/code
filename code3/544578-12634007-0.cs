    class Program
    {
        static AutoResetEvent e1 = new AutoResetEvent(false);
        static AutoResetEvent e2 = new AutoResetEvent(false);
        private static object lockObject = new object();
        private static void threadProc()
        {
            lock (lockObject)
            {
                e1.Set();
                e2.WaitOne();
                Console.WriteLine("got event");
            }
        }
        private static int finalized = 0;
        public class finalizerTest
        {
            ~finalizerTest()
            {
                try
                {
                    throw new NullReferenceException();
                }
                finally
                {
                    Interlocked.Increment(ref finalized);
                }
            }
        }
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem((a) => threadProc());
            e1.WaitOne();
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            {
                finalizerTest f = new finalizerTest();
            }
            
            //uncommenting this will cause logging to happen as expected
            /*
            while (finalized == 0)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
             */
            
        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("in handler -- pre lock");
            e2.Set();
            lock (lockObject)
            {
                Console.WriteLine("in handler");
            }
        }
    }
