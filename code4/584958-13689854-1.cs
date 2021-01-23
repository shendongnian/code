    // outside method MakeAsyncRequest
    var task = MakeAsyncRequest(string url);
    
    task.ContinueWith(t => 
      // check tasks state or use TaskContinuationOption
      // handing error condition and result
    );
    
    try
    {
      task.Wait(); // will throw
      Console.WriteLine(task.Result); // will throw as well
    }
    catch(AggregateException ae)
    {
      // Note you should catch AggregateException instead of
      // original excpetion
      Console.WriteLine(ae.InnerException);
    }
