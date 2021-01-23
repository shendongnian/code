    class Program
        {
            //public delegate int SomeDelegate(int x);
    
            static void Main(string[] args)
            {
                Console.WriteLine("This is the CallBack Pattern Technique for Asynchronous Delegates in Threading");
                Console.WriteLine("");
                Func<int,int> sd = SquareNumber;
                Console.WriteLine("[{0}] Before SquareNumber Method invoked.", Thread.CurrentThread.ManagedThreadId);
                IAsyncResult asyncRes = sd.BeginInvoke(10, new AsyncCallback(CallbackMethod), null);
                Console.WriteLine("[{0}] Back in Main after SquareNumber Method invoked. Doing Extra Processing.", Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("[{0}] Main method processing completed.", Thread.CurrentThread.ManagedThreadId);
                Console.ReadLine();
            }
    
            static int SquareNumber(int a)
            {
                Console.WriteLine("[{0}] Inside SquareNumber  - invoked. Processing......", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(5000);
                return a * a;
            }
    
            static void CallbackMethod(IAsyncResult asyncRes)
            {
                Console.WriteLine("[{0}] Callback Invoked", Thread.CurrentThread.ManagedThreadId);
                AsyncResult ares = (AsyncResult)asyncRes;
                Func<int,int> delg = (Func<int,int>)ares.AsyncDelegate;
                int res = delg.EndInvoke(asyncRes);
                Console.WriteLine("[{1}] Result = {0}", res, Thread.CurrentThread.ManagedThreadId);
            }
        }
