    private void Initialize()
    {
      var dueTime = TimeSpan.FromSeconds(5);
      var interval = TimeSpan.FromSeconds(5);
      
      // TODO: Add a CancellationTokenSource and supply the token here instead of None.
      RunPeriodicAsync(OnTick, dueTime, interval, CancellationToken.None);
    }
    private void OnTick()
    {
      // TODO: Your code here
    }
