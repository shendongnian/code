    var block = new ActionBlock<string>(HandleResponse);
    var tasks = new[]
    {
      client.GetAsync("http://example.com/"),
      client.GetAsync("http://stackoverflow.com/"),
    };
    foreach (var task in tasks)
    {
      task.ContinueWith(t =>
      {
        if (t.IsFaulted)
          ((IDataflowBlock)block).Fault(t.Exception.InnerException);
        else
          block.Post(t.Result);
      });
    }
