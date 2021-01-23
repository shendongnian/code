    public async void RunForestRun(CancellationToken token)
    {
      var t = await Task.Factory.StartNew(async delegate
       {
           while (true)
           {
               await Task.Delay(TimeSpan.FromSeconds(1), token)
                     .ContinueWith(task => { Console.WriteLine("End delay"); });
               this.PrintConsole(1);
            }
        }, token) // drop thread options to default values;
    }
    // And somewhere there
    source.Cancel();
    //or
    token.ThrowIfCancellationRequested(); // try/ catch block requred.
