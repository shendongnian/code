            var cts = new CancellationTokenSource();
            var task = Task.Factory.StartNew(() =>
                {
                    var i = 0;
                    while (true)
                    {
                        Thread.Sleep(1000);
                        cts.Token.ThrowIfCancellationRequested();
                        i++;
                        if (i > 5)
                            throw new InvalidOperationException();
                    }
                }, cts.Token);
            // This one will fire only when task will be faulted:
            task
                .ContinueWith(t => Console.WriteLine("{0} with {1}: {2}", 
                    t.Status, t.Exception.InnerExceptions[0].GetType(), t.Exception.InnerExceptions[0].Message), 
                    TaskContinuationOptions.OnlyOnFaulted);
            // And this one - only when task will be cancelled:
            task
                .ContinueWith(t => Console.WriteLine(t.Status), TaskContinuationOptions.OnlyOnCanceled);
            Console.ReadLine();
            cts.Cancel();
            Console.ReadLine();
