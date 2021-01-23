    private async Task ProcessQueue()
    {
      try
      {
        while (queue.Count != 0)
        {
          Func<Task> command = queue.Dequeue();
          try
          {
            await command();
          }
          catch (Exception ex)
          {
            // Exceptions from your queued tasks will end up here.
            throw;
          }
        }
      }
      finally
      {
        queueProcessor = null;
      }
    }
