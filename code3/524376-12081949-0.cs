    class Program
    {
        static void Main(string[] args)
        {
            var fullAction = RunActionsWithDelay(DoSomething, 2000, DoSomethingElse);
            fullAction.Wait();
            Console.WriteLine("Done");
            Console.ReadLine();
        }
        static Task RunActionsWithDelay(Action first, int delay, Action second)
        {
            var delayedCompletion = new TaskCompletionSource<object>();
            var task = Task.Factory.StartNew(DoSomething);
            task.ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    delayedCompletion.SetException(t.Exception);
                }
                else
                {
                    Timer timer = null;
                    timer = new Timer(s =>
                    {
                        try
                        {
                            DoSomethingElse();
                            delayedCompletion.SetResult(null);
                        }
                        catch (Exception ex)
                        {
                            delayedCompletion.SetException(ex);
                        }
                        finally
                        {
                            timer.Dispose();
                        }
                    }, null, delay, Timeout.Infinite);                    
                }
            });
            return delayedCompletion.Task;
        }
        static void DoSomething()
        {
            Console.WriteLine("Something");
        }
        
        static void DoSomethingElse()
        {
            Console.WriteLine("Something Else");
        }
    }
