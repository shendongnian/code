        private static void Main(string[] args)
        {
            Test test = new Test();
            test.Run();
            
            Console.WriteLine("Type c to cancel");
            if (Console.ReadLine().StartsWith("c"))
            {
                Console.WriteLine("cancellation requested");
                test.CancellationTokenSource.Cancel();
            }
            Console.ReadLine();
        }
        
    }
    public class Test
    {
        private void DoSomething()
        {
            Console.WriteLine("DoSomething runs for 30 seconds ");
            Thread.Sleep(new TimeSpan(0, 0, 0, 30));
            Console.WriteLine("woke up now ");
        }
        public CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();
        public void Run()
        {
            
                var generateReportsTask = Task.Factory.StartNew(() =>
                {
                    CancellationTokenSource.Token.ThrowIfCancellationRequested();
                    Task doSomething = new Task(DoSomething, CancellationTokenSource.Token);
                    doSomething.Start();
                    doSomething.Wait(CancellationTokenSource.Token);
                }, CancellationTokenSource.Token);
                generateReportsTask.ContinueWith(
                    (t) =>
                    {
                        if (t.Exception != null)
                            Console.WriteLine("Exceptions reported :\n " + t.Exception);
                        if (t.Status == TaskStatus.RanToCompletion)
                            Console.WriteLine("Completed report generation task");
                        if (t.Status == TaskStatus.Faulted)
                            Console.WriteLine("Completed reported generation with unhandeled exceptions");
                        if(t.Status == TaskStatus.Canceled)
                            Console.WriteLine("The Task Has been cancelled");
                    });
             
            
        }
    }
