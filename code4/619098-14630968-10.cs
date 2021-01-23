    var task = FooAsync().Then(() => BarAsync()).Then(() => FubarAsync());
    task.ContinueWith(t =>
    {
      if (t.IsFaulted || t.IsCanceled)
      {
        var e = t.Exception.InnerException;
        // exception handling
      }
      else
      {
        Console.WriteLine("All done");
      }
    }, TaskContinuationOptions.ExcecuteSynchronously);
