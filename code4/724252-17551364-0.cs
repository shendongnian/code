    class Program
        {
            static void Main()
            {
    
                var tokenSource2 = new CancellationTokenSource();
                var ct = tokenSource2.Token;
    
                var task = Task.Factory.StartNew(() =>
                {
                    //Replase  with yor animation code
                    
                    int i = 0;
                    while (true)
                    {
    
                        Console.WriteLine(i++/10.0);
                        Task.Delay(100).Wait();
    
                        if (ct.IsCancellationRequested)
                        {
                            return;
                        }
    
                    }
                    // end of replace
                }, tokenSource2.Token);
    
                Task.Delay(10000).Wait(); //replace with Directory.GetFiles() 
    
                tokenSource2.Cancel(); // replace with animation stop code
    
            }
        }
