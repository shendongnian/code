    var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));
    var token = cts.Token;
    Task<ProductEventArgs>.Factory.StartNew(() =>
    {
        try
        {
            // occasionally, execute this line:
            token.ThrowIfCancellationRequested();
        }
        catch (OperationCanceledException)
        {
            return new ProductEventArgs() { E = new Exception("timeout") };
        }
        catch (Exception e)
        {
            return new ProductEventArgs() { E = e };
        }
    }).ContinueWith((x) => handleResult(x.Result), TaskScheduler.FromCurrentSynchronizationContext());
