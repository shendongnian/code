    class Whatever : IWhatever
    {
      public Task LoadStateAsync()
      {
        ... // fast-running synchronous code
        return Task.FromResult<object>(null);
      }
    }
