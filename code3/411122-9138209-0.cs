    static void Main(string[] args)
        {
            CancellationTokenSource token = null;
            BlockingCollection<string> coll = new BlockingCollection<string>();
            var t = Task.Factory.StartNew(state =>
                       {
                           token = new CancellationTokenSource();
                           try
                           {
                               foreach (var broadcast in coll.GetConsumingEnumerable(token.Token))
                               {
                                   if (token.IsCancellationRequested)
                                   {
                                       return;
                                   }
                               }
                           }
                           catch (OperationCanceledException)
                           {
                               Console.WriteLine("Cancel");
                               return;
                           }
                       }, "TaskSubscribe", TaskCreationOptions.LongRunning);
            Thread.Sleep(1000);
            token.Cancel();
            t.Wait();
        }
