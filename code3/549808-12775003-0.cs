    public void HandleMessage(string message)
    {
        Task.Factory.StartNew(async delegate
        {
            while (queue.TryDequeue(out message));
            {
               await HandleMessageAsync(message);
            }
        });
    }
