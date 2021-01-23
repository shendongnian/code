    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace DelayImplementation
    {
        class Program
        {
            static void Main(string[] args)
            {
                System.Threading.CancellationTokenSource tcs = new System.Threading.CancellationTokenSource();
    
                int id = 1;
                Console.WriteLine(string.Format("Starting new delay task {0}. This one will be cancelled.", id));
                Task delayTask = Delay(8000, tcs.Token);
                HandleTask(delayTask, id);
    
                System.Threading.Thread.Sleep(2000);
                tcs.Cancel();
    
                id = 2;
                System.Threading.CancellationTokenSource tcs2 = new System.Threading.CancellationTokenSource();
                Console.WriteLine(string.Format("Starting delay task {0}. This one will NOT be cancelled.", id));
                var delayTask2 = Delay(4000, tcs2.Token);
                HandleTask(delayTask2, id);
    
                System.Console.ReadLine();
            }
    
            private static void HandleTask(Task delayTask, int id)
            {
                delayTask.ContinueWith(p => Console.WriteLine(string.Format("Task {0} was cancelled.", id)), TaskContinuationOptions.OnlyOnCanceled);
                delayTask.ContinueWith(p => Console.WriteLine(string.Format("Task {0} was completed.", id)), TaskContinuationOptions.OnlyOnRanToCompletion);
            }
    
            static Task Delay(int delayTime, System.Threading.CancellationToken token)
            {
                TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
    
                if (delayTime < 0) throw new ArgumentOutOfRangeException("Delay time cannot be under 0");
    
                System.Threading.Timer timer = null;
                timer = new System.Threading.Timer(p =>
                {
                    timer.Dispose(); //stop the timer
                    tcs.TrySetResult(null); //timer expired, attempt to move task to the completed state.
                }, null, delayTime, System.Threading.Timeout.Infinite);
    
                token.Register(() =>
                    {
                        timer.Dispose(); //stop the timer
                        tcs.TrySetCanceled(); //attempt to mode task to canceled state
                    });
    
                return tcs.Task;
            }
        }
    }
