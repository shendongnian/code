    var cts = new CancellationTokenSource();
    var task = Task.Factory.StartNew(() =>
        {
            var i = 0;
            try
            {
                while (true)
                {
                    Thread.Sleep(1000);
    
                    cts.Token.ThrowIfCancellationRequested();
    
                    i++;
    
                    if (i > 5)
                        throw new InvalidOperationException();
                }
            }
            catch
            {
                Console.WriteLine("i = {0}", i);
                throw;
            }
        }, cts.Token);
    
    task.ContinueWith(t => 
            Console.WriteLine("{0} with {1}: {2}", 
                t.Status, 
                t.Exception.InnerExceptions[0].GetType(), 
                t.Exception.InnerExceptions[0].Message
            ), 
            TaskContinuationOptions.OnlyOnFaulted);
    task.ContinueWith(t => 
            Console.WriteLine(t.Status), 
            TaskContinuationOptions.OnlyOnCanceled);
    
    Console.ReadLine();
    
    cts.Cancel();
    
    Console.ReadLine();
