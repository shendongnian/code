    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    class Program
    {
        static void Main()
        {
            Delay(2000).ContinueWith(_ => Console.WriteLine("Done"));
            Console.Read();
        }
    
        static Task Delay(int milliseconds)
        {
            var tcs = new TaskCompletionSource<object>();
            new Timer(_ => tcs.SetResult(null)).Change(milliseconds, -1);
            return tcs.Task;
        }
    }
