    private static void Main(string[] args)
    {    
      var connectionString = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];
      _queueClient = QueueClient.CreateFromConnectionString(connectionString, "MyQueue");
      for (var i = 0; i < 25; i++ )
        MyMessageReceiveAsync();
      Console.WriteLine("Waiting for messages...");
      Console.ReadKey();
      _queueClient.Close();
    }
    private static async Task MyMessageReceiveAsync()
    {
      while (true)
      {
        using (var message = await _queueClient.ReceiveAsync(TimeSpan.FromMinutes(5)))
        {
          try
          {
            var msg = message.GetBody<string>();
            Console.WriteLine("Message: " + msg);
            if (_queueClient.Mode == ReceiveMode.PeekLock)
            {
              // Mark brokered message as completed at which point it's removed from the queue.
              await message.CompleteAsync();
            }
          }
          catch (Exception ex)
          {
            if (_queueClient.Mode == ReceiveMode.PeekLock)
            {
              // unlock the message and make it available 
              message.Abandon();
            }
            Console.WriteLine("Exception was thrown: " + ex.GetBaseException().Message);
          }
        }
      }
    }
