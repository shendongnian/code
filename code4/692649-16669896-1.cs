    class Program
    {
         public static async Task<int> UsingAsyncModifier()
        {
            return 10;
        }
    
        public static Task<int> UsingTaskCompletionSource()
        {
            TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
            tcs.SetResult(10);
            return tcs.Task;
        }
        public static Task<int> UsingTaskFromResult()
        {
            return TaskEx.FromResult(10);
        }
        static void Main(string[] args)
        {
          //DateTime t = DateTime.Now;
          Stopwatch timer = new Stopwatch();
          const int repeat = 1000*1000; // Results volatile while repeat grows.
          Console.WriteLine("Repeat {0} times.", repeat);
           
            int j = 0;
            //DateTime t = DateTime.Now;
            timer.Start();
            for (int i = 0; i < repeat; i++)
            {
                j += UsingAsyncModifier().Result;
            }
            timer.Stop();
            Console.WriteLine("UsingAsyncModifier: {0}"
                              , timer.ElapsedMilliseconds);
            //t = DateTime.Now;
            timer.Reset();
    
            j = 0;
            timer.Start();
            for (int i = 0; i < repeat; i++)
            {
                j += UsingTaskCompletionSource().Result;
            }
            timer.Stop();
            Console.WriteLine("UsingTaskCompletionSource: {0}"
                               , timer.ElapsedMilliseconds);
            //t = DateTime.Now;
            timer.Reset();
            j = 0;
            timer.Start();
            for (int i = 0; i < repeat; i++)
            {
              j += UsingTaskFromResult().Result;
            }
            timer.Stop();
            Console.WriteLine("UsingTaskFromResult: {0}"
                              , timer.ElapsedMilliseconds);
    
            Console.ReadLine();
        }
    }
