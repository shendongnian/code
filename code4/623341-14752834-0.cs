    public static class MyAzureExtensions
    {
      public static Task<BrokeredMessage> ReceiveAsync(this QueueClient @this,
          TimeSpan serverWaitTime)
      {
        return Task<BrokeredMessage>.Factory.FromAsync(
            @this.BeginReceive, @this.EndReceive, serverWaitTime, null);
      }
      public static Task CompleteAsync(this BrokeredMessage @this)
      {
        return Task.Factory.FromAsync(@this.BeginComplete, @this.EndComplete, null);
      }
    }
